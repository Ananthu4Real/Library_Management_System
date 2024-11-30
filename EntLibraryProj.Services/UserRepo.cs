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

        public void AddItem(string uname, int itemID)
        {
            LibraryUser? user = GetLibraryUser(uname);
            if (user == null) { return; }
            user.itemId = itemID;
            _context.SaveChanges();

        }

        public LibraryUser? GetLibraryUser(string uname)
        {
            LibraryUser? user = _context.UserTable.Include("Item").ToList().Where(e => e.UserName == uname).FirstOrDefault();
            return user;
        }
    }
}
