
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Solisystems.Domain.Entities
{
    public class ProductEntity  
    {
        [Key]
        public string ProductCode { get; set; }

        public string CategoryCode { get; set; }

        public string ProductName { get; set; }

        [ForeignKey("CategoryCode")]
        public virtual Category? Category { get; set; } 

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
