using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntLibraryProj.Entities
{
    public class LibraryItem
    {
        [Key]
        public int ItemId { get; set; }
        public string? Category { get; set; }
        public string? ItemName { get; set; }
        public string? CreatorName { get; set; }
        public string? Publisher { get; set; }
        public string? OriginCountry { get; set; }
        public string? ItemDescription { get; set; }
        public string? Genre { get; set; }  
        public int? Inventory { get; set; }
        public int? Available { get; set; }
        public DateOnly? DateAdded { get; set; }
    }

    /*
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category CategoryName { get; set; }
    */

    public enum ItemType
    {
        Book,
        Movie
    }
}
