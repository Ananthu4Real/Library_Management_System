using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntLibraryProj.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string CategoryName {  get; set; }
    }
}
