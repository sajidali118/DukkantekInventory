using System;

namespace Dukkantek.Domain.Entities
{
    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, ISoftDelete, IEntity<TPrimaryKey>
    {

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public long? DeletedBy { get; set; }
    }
    /// <summary>
    /// shortcut for FUllAuditedEntity<int>
    /// </summary>
    public abstract class FullAuditedEntity : FullAuditedEntity<long>
    {
        public FullAuditedEntity()
        {

        }
    }
}
