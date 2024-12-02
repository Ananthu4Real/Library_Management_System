using EntLibraryProj.Entities;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    /// <summary>
    /// Enables crud operations for Library Items
    /// </summary>
    public class LibraryRepo : ILibraryService
    {
        
        private readonly LibraryDbContext _context;
        /// <summary>
        /// Constructor, adds the db context
        /// </summary>
        /// <param name="context"></param>
        public LibraryRepo(LibraryDbContext context)
        {
            _context = context;
        }
        //Adds an library item to the table
        public void AddItem(LibraryItem item)
        {
            _context.LibraryItems.Add(item);
            _context.SaveChanges();
        }
        //Deletes an item based on id, if it is not null
        public void DeleteItem(int id)
        {
            LibraryItem? L = _context.LibraryItems.Find(id);
            if (L == null) { return; }
            _context.LibraryItems.Remove(L);
            _context.SaveChanges();
        }
        //Gets a single item based on id
        public LibraryItem? GetItem(int id)
        {
            LibraryItem? L = _context.LibraryItems.Find(id);
            return L;
        }
        //Gets items list
        public List<LibraryItem> GetItems()
        {
            return _context.LibraryItems.ToList();
        }
        /// <summary>
        /// Updates each of the fields of the item using the inputted LibraryItem
        /// </summary>
        /// <param name="item"></param>
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
        /// <summary>
        /// Used for checking out books. Checks to make sure there is actually a book available
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckOutBook(int id)
        {
            LibraryItem? item = GetItem(id);
            if (item == null) { return false; }
            if (item.Available > 0)
            {
                item.Available--;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns a book, adding an available item, so long as it doesn't exceed inventory.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReturnBook(int id)
        {
            LibraryItem? item = GetItem(id);
            if (item == null) { return false; }
            if (item.Available < item.Inventory)
            {
                item.Available++;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
