using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Entities
{
    public class User
    {
        public int LibraryCardNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public virtual UserType UserTypeName {get; set;}
        //public int 
    }
}
