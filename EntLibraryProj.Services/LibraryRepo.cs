using EntLibraryProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public class LibraryRepo : ILibraryService
    {
        private readonly LibraryDbContext _context;

        public LibraryRepo(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddItem(LibraryItem item)
        {
            _context.LibraryItems.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(LibraryItem item)
        {
            LibraryItem? L = _context.LibraryItems.Find(item.ItemId);
            if (L == null) { return; }
            _context.LibraryItems.Remove(L);
            _context.SaveChanges();
        }

        public LibraryItem? GetItem(int id)
        {
            LibraryItem? L = _context.LibraryItems.Find(id);
            return L;
        }

        public IEnumerable<LibraryItem> GetItems()
        {
            return _context.LibraryItems;
        }

        public void UpdateItem(LibraryItem item)
        {
            LibraryItem? L = _context.LibraryItems.Find(item.ItemId);
            if (L == null) { return; }
            L.TestId = item.TestId;
            L.type = item.type;
            L.Genre = item.Genre;
            L.Inventory = item.Inventory;
            L.Available = item.Available;
            L.DateAdded = item.DateAdded;
            L.Edition = item.Edition;
            _context.SaveChanges();
        }
    }
}
