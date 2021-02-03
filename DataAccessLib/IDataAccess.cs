using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
namespace DataAccessLib
{
    /// <summary>
    /// Interface for DataAccessLayer
    /// </summary>
    public interface IDataAccess
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
