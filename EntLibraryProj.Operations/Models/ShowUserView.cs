using EntLibraryProj.Entities;

namespace EntLibraryProj.Operations.Models
{
    public class ShowUserView
    {
        //Created to display users and their roles properly for the ShowUsers view
        public List<LibraryUser> LibraryUsers { get; set; } = new List<LibraryUser>();
        public List<string> Roles { get; set; } = new List<string>();

    }
}
