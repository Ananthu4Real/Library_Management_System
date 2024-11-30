using EntLibraryProj.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntLibraryProj.Entities
{
    public class LibraryItem
    {
        [Key]
        [Required(ErrorMessage = "Id is required")] // Validaiton attribute 'Required'
        [Range(1, 10000000)]
        public int LibItemId { get; set; }
        [Required(ErrorMessage = "Must Choose")]    //Validations here prevents it from being outside of valid ranges or empty, and displays error message
        [Range(1, 9)]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        [Required(ErrorMessage = "Name can't be empty.")]
        [StringLength(500, ErrorMessage = "Name length is 1 - 500", MinimumLength = 1)]
        public string? ItemName { get; set; }
        [Required(ErrorMessage = "Name can't be empty.")] 
        [StringLength(500, ErrorMessage = "Name length is 1 - 500", MinimumLength = 1)]
        public string? CreatorName { get; set; }
        [Required(ErrorMessage = "Can't be empty.")]
        [StringLength(50, ErrorMessage = "Name length is 1 - 50", MinimumLength = 1)]
        public string? Publisher { get; set; }
        [Required(ErrorMessage = "Can't be empty.")]
        [StringLength(50, ErrorMessage = "Name length is 1 - 50", MinimumLength = 1)]
        public string? OriginCountry { get; set; }
        public string? ItemDescription { get; set; }
        [Required(ErrorMessage = "Can't be empty.")] 
        [StringLength(50, ErrorMessage = "Name length is 1 - 50", MinimumLength = 1)]
        public string? Genre { get; set; }
        [Required(ErrorMessage = "Inventory is required")] // Validaiton attribute 'Required'
        [Range(1, 1000000)]
        public int? Inventory { get; set; }
        [Required(ErrorMessage = "Number Available is required")] // Validaiton attribute 'Required'
        [Range(1, 1000000)]
        public int? Available { get; set; }
        public string? ImageURL {  get; set; }
        [Required(ErrorMessage = "Can't be empty.")]
        public string? DateAdded { get; set; }
        [Required(ErrorMessage = "Can't be empty.")]
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
