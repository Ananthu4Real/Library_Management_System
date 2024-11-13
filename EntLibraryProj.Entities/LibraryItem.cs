using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntLibraryProj.Entities
{
    public class LibraryItem
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test? Item { get; set; }

        public string? type { get; set; }
        public string? Genre { get; set; }  
        public int? Inventory { get; set; }
        public int? Available { get; set; }

        public string? DateAdded { get; set; }
        public string? Edition { get; set; }


    }
}
