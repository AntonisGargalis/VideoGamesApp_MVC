using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace VideoGamesApp.Models
{
    public class Category
    {
        [Key] // data annotation primary key for id
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
