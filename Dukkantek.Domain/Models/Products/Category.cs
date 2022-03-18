using Dukkantek.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Domain.Models.Products
{
    public class Category : FullAuditedEntity, IEntity
    {
        [Required(ErrorMessage = "Category Name is required.")]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
