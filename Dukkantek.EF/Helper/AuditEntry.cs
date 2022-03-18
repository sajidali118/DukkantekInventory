using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Dukkantek.Domain.Models.Logs;
using static Dukkantek.Domain.Utilities.EnumsData;

namespace TUTORPK.EntityFrameWork.Helper
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
        public AuditType AuditType { get; set; }
        public long AuditUser { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
        public List<string> ChangedColumns { get; } = new List<string>();


        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public Audit ToAudit()
        {
            var audit = new Audit
            {
                TableName = TableName,
                AuditType = AuditType.ToString(),
                AuditUser = AuditUser,
                AuditDateTimeUtc = DateTime.UtcNow,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                ChangedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns)
            };
            return audit;
        }
    }
}
