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
        /// <summary>
        /// Allows user to add items to their item repo. Only 3 item slots avail.
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public bool AddLibItem(string uname, int itemID)
        {
            LibraryUser? user = GetLibraryUser(uname);
            if (user == null) { return false; }

            if (user.itemId1 == null)  //already checked out
            {
                user.itemId1 = itemID;

            }
            else if (user.itemId2 == null)
            {
                user.itemId2 = itemID;
            }
            else if (user.itemId3 == null)
            {
                user.itemId3 = itemID;
            }
            else
            {
                return false; //no space
            }
            _context.SaveChanges();
            return true;

        }
        /// <summary>
        /// Removes items from the slots, allowing user to fill them again upon
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public bool RemoveLibItem(string uname, int itemID)
        {
            LibraryUser? user = GetLibraryUser(uname);
            if (user == null) { return false; }
            if (user.itemId1 == itemID)
            {
                user.itemId1 = null;
            }
            else if (user.itemId2 == itemID)
            {
                user.itemId2 = null;
            }
            else if (user.itemId3 == itemID)
            {
                user.itemId3 = null;
            }
            else
            {
                return false;
            }
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Gets library user, including matching items to their username
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        public LibraryUser? GetLibraryUser(string uname)
        {
            LibraryUser? user = _context.UserTable.Include("Item1").Include("Item2").Include("Item3").ToList().Where(e => e.UserName == uname).FirstOrDefault();
            return user;
        }
        /// <summary>
        /// Get users as a list with their matching items
        /// </summary>
        /// <returns></returns>
        public List<LibraryUser> GetUsers()
        {
            List<LibraryUser> users = _context.UserTable.Include("Item1").Include("Item2").Include("Item3").ToList();
            return users;
        }
        /// <summary>
        /// Used to get a role from the given item, where the id matches the rolename
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetRole(string item) //Get A role with specific userID
        {
            Microsoft.AspNetCore.Identity.IdentityUserRole<string>? role = _context.UserRoles.Where(e => e.UserId == item).FirstOrDefault(); //Get Role ID Connected to user
            if (role == null) { return "ERROR"; }
            string roleid = role.RoleId;

            string? name = _context.Roles.Where(e => e.Id == roleid).FirstOrDefault()?.Name; //GetRoleName With Id
            if (name == null) { return "Error"; }
            return name;
        }
    }
}
