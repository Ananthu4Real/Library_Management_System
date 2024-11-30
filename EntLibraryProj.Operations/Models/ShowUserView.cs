using EntLibraryProj.Entities;

namespace EntLibraryProj.Operations.Models
{
    public class ShowUserView
    {
        public List<LibraryUser> LibraryUsers { get; set; } = new List<LibraryUser>();
        public List<string> Roles { get; set; } = new List<string>();

    }
}
