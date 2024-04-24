using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace VideoGamesApp.Models
{
    public class Category
    {
        [Key] // data annotation primary key for id
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
