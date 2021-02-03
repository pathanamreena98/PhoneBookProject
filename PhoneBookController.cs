using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EntitiesLib;
using System.Net.Http;
namespace PhoneBookApp2.Controllers
{
    public class PhoneBookController : Controller
    {
        // GET: PhoneBook
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult MainPage()
        {
            return View();
        }

        /// <summary>
        /// getting categories
        /// </summary>
        /// <returns></returns>

        public ActionResult Categories()
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client =new HttpClient())
            {
                client.BaseAddress = uri;
                //giving base address
                var result = client.GetStringAsync("PhoneBookApi").Result;
                var lstCategory = JsonConvert.DeserializeObject<List<Category>>(result);
                return View(lstCategory);
            }
        }
        /// <summary>
        /// getting contact details 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ContactDetails(int id)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                //base address
                var result = client.GetStringAsync("PhoneBookApi/" + id).Result;
                var lstContacts = JsonConvert.DeserializeObject<List<Contact>>(result);
                return View(lstContacts);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// create category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        

        public ActionResult Create(Category category)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client =new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("PhoneBookApi", category).Result;
                if(result.IsSuccessStatusCode==true)
                {
                    //redirecting to displaying categories
                    return RedirectToAction("Categories");
                }
                else
                {
                    //displaying error message "record is not inserted
                    ViewData.Add("msg", "record is not inserted");
                }
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        /// <summary>
        /// creating contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult CreateContact(Contact contact)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("PhoneBookApi/AddContact", contact).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    //redirecting to diplaying the contacts after adding new contact
                    return RedirectToAction("ContactDetails",new { id = contact.CategoryId });
                }
                else
                {
                    //displaying error message "record is not inserted"
                    ViewData.Add("msg", "record is not inserted");
                }
                return View();
            }
        }
        /// <summary>
        /// deleting category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]

        public ActionResult Delete(int id)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("PhoneBookApi/"+id).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    //displaying message "record deleted successfully"
                    
                    TempData.Add("msg", "record deleted successfully");
                }
                else
                {
                    //displaying message "record could not delete due to some error"
                    TempData.Add("msg", "record could not delete due to some errror");
                }
                return RedirectToAction("Categories");
            }
        }
        /// <summary>
        /// deleting contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("PhoneBookApi/DeleteContact" + id).Result;
                return RedirectToAction("ContactDetails");
            }
        }
        /// <summary>
        /// editing category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PhoneBookApi/" + id).Result;
                var category = JsonConvert.DeserializeObject<Category>(result);
                return View(category);
            }
        }
        /// <summary>
        /// editing contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            Uri uri = new Uri("http://localhost:60834/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PutAsJsonAsync("PhoneBookApi/" + contact.ContactId,contact).Result;
                return RedirectToAction("ContactDetails");
                  
            }
        }

    }
}