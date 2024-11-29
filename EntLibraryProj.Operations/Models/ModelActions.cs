using EntLibraryProj.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntLibraryProj.Operations.Models
{
    public class ModelActions
    {
        public static List<SelectListItem> CreateSelectListItemListForCategories(List<Category> categories)
        {
            //Converts list of departments into a list of SelectListItem type, for dropdown list
            List<SelectListItem> listOfCategories = new List<SelectListItem>();
            foreach (var cat in categories)
            {
                listOfCategories.Add(new SelectListItem
                {
                    Text = cat.CategoryName,
                    Value = cat.CategoryId.ToString()
                });
            }
            return listOfCategories;
        }
    }
}
