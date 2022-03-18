using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Domain.Utilities
{
    public class EnumsData
    {
        // *****  Any changes to these enums must be reflected in the database ******//

        // ****** Make suer User Roles values are same as in database

        public enum ProductStatus
        {
            [Display(Name = "Sold")]
            SOLD = 1,
            [Display(Name = "In Stock")]
            INSTOCK = 2,
            [Display(Name = "Damaged")]
            DAMAGED = 3,

        }


        public enum AuditType
        {
            None = 0,
            Create = 1,
            Update = 2,
            Delete = 3
        }

    }
}
