using EntLibraryProj.Entities;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public interface IUserService
    {
        //Gets the library user, adds an item to their name, removes said items. 
        LibraryUser? GetLibraryUser(string uname);
        bool AddLibItem(string uname, int itemID);
        bool RemoveLibItem(string uname, int itemID);

        //Gets users
        List<LibraryUser> GetUsers();
        //Gets roles
        string GetRole(string item);
    }
}
