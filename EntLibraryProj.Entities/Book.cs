using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Entities
{
    public class Book : Test
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public int PageCount { get; set; }

   
        public override List<string> Tags()
        {
            List<string> tags = new List<string>();
            tags.Add(Author);
            tags.Add(Title);
            tags.Add(Description);
            tags.Add(Created.ToString());
            tags.Add(PageCount.ToString());
            return tags;
        }

        public override List<string> TagNames()
        {
            List<string> tags = new List<string>();
            tags.Add("Author");
            tags.Add("Title");
            tags.Add("Description");
            tags.Add("Created");
            tags.Add("Page Count");
            return tags;
        }
    }
}
