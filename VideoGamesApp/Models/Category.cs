using System.ComponentModel.DataAnnotations;
namespace VideoGamesApp.Models
{
    public class Category
    {
        [Key] // data annotation primary key for id
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
