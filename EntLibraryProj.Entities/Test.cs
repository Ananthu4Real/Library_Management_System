using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Entities
{
    public abstract class Test
    {
      [Key]
      public int Id { get; set; }
      public abstract List<string> Tags();
      public abstract List<string> TagNames();
    }
}
