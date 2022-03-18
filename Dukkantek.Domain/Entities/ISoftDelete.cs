using System;

namespace Dukkantek.Domain.Entities
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public long? DeletedBy { get; set; }
    }
}
