using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Entities
{
    public class CreateRoleViewModel
    /// <summary>
    /// Principle: Ian. Used to add roles to the role table
    /// </summary>
    {
        [Required]
        public string RoleName { get; set; }
    }
}
