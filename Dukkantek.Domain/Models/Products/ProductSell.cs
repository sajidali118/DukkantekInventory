using Dukkantek.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukkantek.Domain.Models.Products
{
    public class ProductSell : FullAuditedEntity, IEntity
    {
        public long? ProductId { get; set; }
        public string CustomerName { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
