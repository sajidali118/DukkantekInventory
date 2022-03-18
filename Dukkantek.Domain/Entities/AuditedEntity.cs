using System;

namespace Dukkantek.Domain.Entities
{
    public abstract class AuditedEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual long? CreatedBy { get; set; }
        public virtual DateTime? LastModifiedOn { get; set; }
        public virtual long? LastModifiedBy { get; set; }
    }

    /// <summary>
    /// shortcut for AuditedEntity<int>
    /// </summary>
    public abstract class AuditiedEntity : AuditedEntity<long>
    {

    }

}
