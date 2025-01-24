using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNet_Bookstore.Models
{
    public class Category
    {
        // pk field should always be called either Id or <ClassName>Id e.g. CategoryId
        [Display(Name = "Category ID")]
        [Range(1, 999999)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "A customized error message")]
        public string Name { get; set; }
    }
}
