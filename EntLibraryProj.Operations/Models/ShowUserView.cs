using EntLibraryProj.Entities;

namespace EntLibraryProj.Operations.Models
{
    public class ShowUserView
    {
        public List<LibraryUser> LibraryUsers { get; set; }
        public List<string> Roles { get; set; }

    }
}
