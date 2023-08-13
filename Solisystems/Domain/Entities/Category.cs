
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Solisystems.Domain.Entities
{
    public class Category
    {
        [Key]
        public string CategoryCode { get; set; }
        
        public string CategoryName { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ProductEntity>? Products { get; set; }

    }
}
