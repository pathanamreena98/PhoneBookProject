using EntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib;
using ExceptionLib;
namespace BusinessLib
{
    public class BusinessLayer : IBusiness
    {
        /// <summary>
        /// for adding contact
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(Contact contact)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AddContact(contact);
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for adding category
        /// </summary>
        /// <param name="category"></param>
        public void AddCategory(Category category)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.AddCategory(category);
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for deleting contact
        /// </summary>
        /// <param name="id"></param>
        public void DeleteContactById(int id)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.DeleteContactById(id);
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for deleting category by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCategoryById(int id)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.DeleteCategoryById(id);
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for getting all category names
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategoryNames()
        {
            try
            {
                DataAccess dal = new DataAccess();
                var lstcategories = dal.GetAllCategoryNames();
                return lstcategories;
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for getting all contacts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contact> GetAllContactsByCId(int id)
        {
            try
            {
                DataAccess dal = new DataAccess();
                var lstcontacts = dal.GetAllContactsByCId(id);
                return lstcontacts;
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for updating contact
        /// </summary>
        /// <param name="contact"></param>
        public void UpdateContactById(Contact contact)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateContactById(contact);
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// for updating category
        /// </summary>
        /// <param name="category"></param>
        public void UpdateCategoryById(Category category)
        {
            try
            {
                DataAccess dal = new DataAccess();
                dal.UpdateCategoryById(category);
            }
            catch (PbException ex)
            {
                throw ex;
            }
        }
        
    }
}
