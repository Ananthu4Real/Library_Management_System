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
        /// <summary>
        /// Repo constructor gets the library db context for its operations to work
        /// </summary>
        /// <param name="libraryDbContext"></param>
        public CategoryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        //Gets IEnumerable<Category> object for the category table's categories
        public IEnumerable<Category> ListCategory()
        {
            return _libraryDbContext.CategoryInfo;
        }
    }
}
