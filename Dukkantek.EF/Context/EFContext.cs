﻿using Dukkantek.Domain.Models.Logs;
using Dukkantek.Domain.Models.Products;
using Dukkantek.EF.Context.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TUTORPK.EntityFrameWork.Helper;
using static Dukkantek.Domain.Utilities.EnumsData;

namespace Dukkantek.EntityFrameWork.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductSell> ProductSells { get; set; }
        public DbSet<Audit> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
        public static void SetValue(object inputObject, string propertyName, object propertyVal)
        {
            Type type = inputObject.GetType();
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName);
            Type propertyType = propertyInfo.PropertyType;
            var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
            propertyVal = Convert.ChangeType(propertyVal, targetType);
            propertyInfo.SetValue(inputObject, propertyVal, null);

        }
        void InitializeAudit()
        {
            var changeList = this.ChangeTracker.Entries().ToList();
            foreach (var entry in changeList)
            {
                var type = entry.Entity.GetType();
                switch (entry.State)
                {
                    case EntityState.Modified:
                        if (type.GetProperties().Where(x => x.Name == "LastModifiedOn").FirstOrDefault() != null)
                        {
                            DateTime? updatedOn = DateTime.Now;
                            SetValue(entry.Entity, "LastModifiedOn", updatedOn);

                        }
                        break;
                    case EntityState.Added:

                        if (type.GetProperties().Where(x => x.Name == "CreatedOn").FirstOrDefault() != null)
                        {
                            SetValue(entry.Entity, "CreatedOn", DateTime.Now);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public override int SaveChanges()
        {

            InitializeAudit();


            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            InitializeAudit();

            //return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChanges(auditEntries);
            return result;
        }
        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var currentValues = entry.CurrentValues;
                var originalValues = entry.OriginalValues;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Metadata.GetTableName();
                auditEntries.Add(auditEntry);
                // IEnumerable<string> modifiedProperties = entry.Metadata.get();
                foreach (var property in entry.Properties)
                {
                    /// string dbColumnName = property.Metadata.GetColumnName();
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.AuditType = AuditType.Create;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.AuditType = AuditType.Delete;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                var oldValue = originalValues[propertyName] != null ? originalValues[propertyName].ToString() : null;
                                var newValue = currentValues[propertyName] != null ? currentValues[propertyName].ToString() : null;

                                if (oldValue == newValue) { continue; };

                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                auditEntry.AuditType = AuditType.Update;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }
        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                AuditLogs.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
        }
    }
}