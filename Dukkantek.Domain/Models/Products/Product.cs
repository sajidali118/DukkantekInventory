using Dukkantek.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Dukkantek.Domain.Utilities.EnumsData;

namespace Dukkantek.Domain.Models.Products
{
    public class Product : FullAuditedEntity, IEntity
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public ProductStatus Status { get; set; }
        public long? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
