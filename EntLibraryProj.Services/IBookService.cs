using EntLibraryProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> GetBooks();
        public Book? GetBook(int id);
        public void DeleteBook(Book book);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
    }
}
