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
        LibraryUser? GetLibraryUser(string uname);
        bool AddLibItem(string uname, int itemID);
        bool RemoveLibItem(string uname, int itemID);


        List<LibraryUser> GetUsers();
        string GetRole(string item);
    }
}
