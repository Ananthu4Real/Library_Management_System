using EntLibraryProj.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntLibraryProj.Entities
{
    public class LibraryItem
    {
        [Key]
        public int LibItemId { get; set; }
        //[Required(ErrorMessage = "Must Choose")]
        //[Range(1,9)]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string? ItemName { get; set; }
        public string? CreatorName { get; set; }
        public string? Publisher { get; set; }
        public string? OriginCountry { get; set; }
        public string? ItemDescription { get; set; }
        public string? Genre { get; set; }  
        public int? Inventory { get; set; }
        public int? Available { get; set; }
        public string? ImageURL {  get; set; }
        public string? DateAdded { get; set; }
        public string? DateCreated { get; set; }
    }

    /*
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category CategoryName { get; set; }
    */

    //public enum ItemType
    //{
    //    Book,
    //    Movie,
    //    Audiobook,
    //    VideoProgram,
    //    VideoGame,
    //    Music,
    //    Software,
    //    ResearchPaper,
    //    Magazine,
    //    Newspaper
    //}
}
