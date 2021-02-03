using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib;
using EntitiesLib;

namespace BusinessLib
{
    /// <summary>
    /// Interface for Business Layer
    /// </summary>
    public interface IBusiness
    {
        List<Category> GetAllCategoryNames();
        void AddCategory(Category category);
        void AddContact(Contact contact);
        void DeleteContactById(int id);
        void DeleteCategoryById(int id);
        List<Contact> GetAllContactsByCId(int id);
        void UpdateContactById(Contact contact);
        void UpdateCategoryById(Category category);

    }
}
