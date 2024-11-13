using EntLibraryProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public class BookRepo : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookRepo(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            Book? B = _context.Books.Find(book.Id);
            if (B == null) { return; }
            _context.Books.Remove(B);
            _context.SaveChanges();
        }

        public Book? GetBook(int id)
        {
            Book? B = _context.Books.Find(id);
            return B;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        public void UpdateBook(Book book)
        {
            Book? B = _context.Books.Find(book.Id);
            if (B == null) { return; }
            
                B.Title = book.Title;
                B.Description = book.Description;
                B.Author = book.Author;
                B.Created = book.Created;
                B.PageCount = book.PageCount;
                _context.SaveChanges();
            
        }
    }
}
