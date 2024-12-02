using EntLibraryProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public interface ICategoryServices
    {
        //Allows listing of categories. By Ian
        public IEnumerable<Category> ListCategory();
    }
}
