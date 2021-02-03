using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntitiesLib;
using BusinessLib;


namespace PhoneBookApp2wepapi.Controllers
{
    public class PhoneBookApiController : ApiController
    {
        /// <summary>
        /// get category names
        /// </summary>
        /// <returns></returns>
        public List<Category> Get()
        {
            BusinessLayer bll = new BusinessLayer();
            var lstCategory = bll.GetAllCategoryNames();
            return lstCategory;
        }
        /// <summary>
        /// get contacts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage res = Request.CreateErrorResponse(HttpStatusCode.OK, "record found");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                var lstContacts = bll.GetAllContactsByCId(id);
                return res = Request.CreateResponse<List<Contact>>(lstContacts);
            }
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        /// <summary>
        /// adding category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]Category category)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record inserted");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                bll.AddCategory(category);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, "record not found");
            }
            return errRes;
        }
        /// <summary>
        /// adding contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [Route("api/PhoneBookApi/AddContact")]
        public HttpResponseMessage AddContact([FromBody] Contact contact)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record inserted");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                bll.AddContact(contact);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        /// <summary>
        /// deleting category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record deleted");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                bll.DeleteCategoryById(id);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        /// <summary>
        /// deleting contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/PhoneBookApi/DeleteContact")]

        public HttpResponseMessage DeleteContact(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record deleted");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                bll.DeleteContactById(id);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        /// <summary>
        /// editing contact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody]Contact contact,int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record updated");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                bll.UpdateContactById(contact);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        /// <summary>
        /// editing category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody] Category category, int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record updated");
            try
            {
                BusinessLayer bll = new BusinessLayer();
                bll.UpdateCategoryById(category);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }

    }
    
}
