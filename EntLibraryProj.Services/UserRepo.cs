using EntLibraryProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public class UserRepo : IUserService
    {
        private readonly LibraryDbContext _context;

        public UserRepo(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddLibItem(string uname, int itemID)
        {
            LibraryUser? user = GetLibraryUser(uname);
            if (user == null) { return; }
            user.itemId = itemID;
            _context.SaveChanges();

        }
        public void RemoveLibItem(string uname, int itemID)
        {
            LibraryUser? user = GetLibraryUser(uname);
            if (user == null) { return; }
            if (user.itemId == itemID)
            {
                user.itemId = null;
                _context.SaveChanges();
            }
        }

        public LibraryUser? GetLibraryUser(string uname)
        {
            LibraryUser? user = _context.UserTable.Include("Item").ToList().Where(e => e.UserName == uname).FirstOrDefault();
            return user;
        }

        public List<LibraryUser> GetUsers()
        {
            List<LibraryUser> users = _context.UserTable.Include("Item").ToList();
            return users;
        }
        public string GetRole(string item) //Get A role with specific userID
        {
            Microsoft.AspNetCore.Identity.IdentityUserRole<string>? role = _context.UserRoles.Where(e => e.UserId == item).FirstOrDefault(); //Get Role ID Connected to user
            if(role == null) { return "ERROR"; }
            string roleid = role.RoleId;

            string? name = _context.Roles.Where(e=>e.Id == roleid).FirstOrDefault()?.Name; //GetRoleName With Id
            if (name == null) { return "Error"; }
            return name;
        }
    }
}
