using System.ComponentModel.DataAnnotations.Schema;

namespace EntLibraryProj.Entities
{
    public class LibraryItem
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category CategoryName { get; set; }
        public string? GenreTags { get; set; }  
        public string? DateAdded { get; set; }
        public string? DateReleased { get; set; }
        public int? InventoryCount { get; set; }
        public int? InventoryTakenOut { get; set; }


    }
}
