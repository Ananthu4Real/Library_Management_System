using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Entities
{
    public class UserType
    {
        [Key] 
        public int UserTypeId { get; set; }
        [DisplayName("UserType")]
        public string UserTypeName { get; set; }
    }
}
