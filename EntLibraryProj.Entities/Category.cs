using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntLibraryProj.Entities
{
    public class Category
    {
        /// <summary>
        /// Principle: Ian. Used to add categories to library items
        /// </summary>
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string CategoryName {  get; set; }
    }
}
