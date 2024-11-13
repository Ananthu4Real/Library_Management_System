using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Entities
{
    public class Movie : Test
    {
        public string? Title { get; set; }
        public string? Director { get; set; }

        public string? Length { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }




        public override List<string> TagNames()
        {
            List<string> tags = new List<string>();
            tags.Add(Title);
            tags.Add(Director);
            tags.Add(Length);
            tags.Add(Description);
            tags.Add(Created.ToString());
            return tags;
        }

        public override List<string> Tags()
        {
            List<string> tags = new List<string>();
            tags.Add("Title");
            tags.Add("Director");
            tags.Add("Length");
            tags.Add("Description");
            tags.Add("Created");
            return tags;
        }
    }
}
