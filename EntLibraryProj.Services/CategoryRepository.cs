using EntLibraryProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public class CategoryRepository : ICategoryServices
    {
        private readonly LibraryDbContext _libraryDbContext;
        public CategoryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public IEnumerable<Category> ListCategory()
        {
            return _libraryDbContext.CategoryInfo;
        }
    }
}
