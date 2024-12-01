using EntLibraryProj.Entities;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public interface ILibraryService
    {
        /// <summary>
        /// Various CRUD operations are implemented in these services
        /// </summary>
        /// <returns></returns>
        public List<LibraryItem> GetItems();
        public LibraryItem? GetItem(int id);
        public void DeleteItem(int id);
        public void AddItem(LibraryItem item);
        public void UpdateItem(LibraryItem item);
        public bool CheckOutBook(int id);
        public bool ReturnBook(int id);
    }
}
