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

        public void DeleteItem(int id)
        {
            LibraryItem? L = _context.LibraryItems.Find(id);
            if (L == null) { return; }
            _context.LibraryItems.Remove(L);
            _context.SaveChanges();
        }

        public LibraryItem? GetItem(int id)
        {
            LibraryItem? L = _context.LibraryItems.Find(id);
            return L;
        }

        public List<LibraryItem> GetItems()
        {
            return _context.LibraryItems.ToList();
        }

        public void UpdateItem(LibraryItem item)
        {
            LibraryItem? L = GetItem(item.LibItemId);
            if (L == null) { return; }
            L.ItemName = item.ItemName;
            L.CreatorName = item.CreatorName;
            L.Publisher = item.Publisher;
            L.OriginCountry = item.OriginCountry;
            L.ItemDescription = item.ItemDescription;
            L.Category = item.Category;
            L.Genre = item.Genre;
            L.Inventory = item.Inventory;
            L.Available = item.Available;
            L.DateAdded = item.DateAdded;
            L.DateCreated = item.DateCreated;
            _context.SaveChanges();
        }
    }
}
