using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgeAdam.Automation.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Required]
        [Key]
        public int CategoryID { get; set; }
        [MaxLength(15)]
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
