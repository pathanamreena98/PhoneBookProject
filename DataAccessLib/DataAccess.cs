using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using ExceptionLib;
using System.Data.SqlClient;
using System.Data;


using System.Configuration;

namespace DataAccessLib
{
    public class DataAccess : IDataAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        public DataAccess()
        {
            //configure connection object
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HCLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        /// <summary>
        /// This method retrieve the category names from the database
        /// </summary>
        public List<Category> GetAllCategoryNames()
        {
            List<Category> lstcategory = new List<Category>();
            try
            {
                //configure command for SELECT statement
                cmd = new SqlCommand();
                cmd.CommandText = "select * from Category";
                //attach the connection with the command
                cmd.Connection = con;

                //open the connection 
                con.Open();

                //execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                //read the records from data reader and add them to the collection 
                while (sdr.Read())
                {
                    Category category = new Category
                    {
                        CategoryId = (int)sdr[0],
                        CategoryName = sdr[1].ToString(),
                    };
                    lstcategory.Add(category);
                }
                //close the data reader 
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new PbException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException(ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
            //returning all the records using collection
            return lstcategory;
        }

        /// <summary>
        /// This method adds Category 
        /// </summary>
        /// <param name="category">it is used to pass the category </param>
        public void AddCategory(Category category)
        {
            try
            {
                //configure command for INSERT statemnt
                cmd = new SqlCommand();
                cmd.CommandText = "insert into Category values(@catid,@catname)";
                //Attach the connection with the command
                cmd.Connection = con;
                cmd.Parameters.Clear();
                //supplying the values to the parameters of the command
                cmd.Parameters.AddWithValue("@catid", category.CategoryId);
                cmd.Parameters.AddWithValue("@catname", category.CategoryName);
                cmd.CommandType = CommandType.Text;
                //open the connection
                con.Open();
                //Execute the Command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PbException("Could not insert data");
                }
            }
            catch (SqlException ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// This method adds Contact 
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(Contact contact)
        {
            try
            {
                //configure command for INSERT statement
                cmd = new SqlCommand();
                cmd.CommandText = "insert into Contact values(@conid,@catid,@fname,@lname,@gender,@cnumber,@emailid,@city,@state,@con,@pic)";
                //Attach connection with the command
                cmd.Connection = con;
                cmd.Parameters.Clear();
                //supply values to the parameters of the command
                cmd.Parameters.AddWithValue("@conid", contact.ContactId);
                cmd.Parameters.AddWithValue("@catid", contact.CategoryId);
                cmd.Parameters.AddWithValue("@fname", contact.FirstName);
                cmd.Parameters.AddWithValue("@lname", contact.LastName);
                cmd.Parameters.AddWithValue("@gender", contact.Gender);
                cmd.Parameters.AddWithValue("@cnumber", contact.ContactNumber);
                cmd.Parameters.AddWithValue("@emailid", contact.EmailId);
                cmd.Parameters.AddWithValue("@city", contact.City);
                cmd.Parameters.AddWithValue("@state", contact.State);
                cmd.Parameters.AddWithValue("@con", contact.Country);
                cmd.Parameters.AddWithValue("@pic", contact.Picture);
                cmd.CommandType = CommandType.Text;
                //open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PbException("Could not insert record!!!");
                }
            }
            catch (SqlException ex)
            {
                throw new PbException("some error has happened!:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("some error has happened!:" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Deletes contact by id
        /// </summary>
        /// <param name="id"></param>

        public void DeleteContactById(int id)
        {
            try
            {
                //configure command for DELETE statement
                cmd = new SqlCommand();
                cmd.CommandText = "delete from Contact where ContactId=@id";
                cmd.CommandType = CommandType.Text;
                //Pass the value to the Parameter
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                //Attach connection to the Command
                cmd.Connection = con;
                //open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PbException("ContactId does not exists");
                }
            }
            catch (SqlException ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Deletes category
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCategoryById(int id)
        {
            try
            {
                //configure command for DELETE statement
                cmd = new SqlCommand();
                cmd.CommandText = "delete from Category where CategoryId=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                //pass value to Parameter
                cmd.Parameters.AddWithValue("@id", id);
                //Attach connection to the command
                cmd.Connection = con;
                //open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PbException("CategoryId does not exists");
                }
            }
            catch (SqlException ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// display all the contacts by retrieving from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contact> GetAllContactsByCId(int id)
        {
            List<Contact> lstcon = new List<Contact>();
            try
            {
                //SELECT Contact by Id
                cmd = new SqlCommand();
                cmd.CommandText = "select Contact.ContactId,Category.CategoryId,Contact.FirstName,Contact.LastName,Contact.Gender,Contact.ContactNumber,Contact.EmailId,Contact.City,Contact.State,Contact.Country,Contact.Picture from Category join Contact on Category.CategoryId = Contact.CategoryId and Contact.CategoryId=@ci";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //configure command parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ci", id);
                //Open the connection
                con.Open();
                //Execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Contact contact = new Contact
                    {
                        //Read the record
                        ContactId = (int)sdr[0],
                        CategoryId = (int)sdr[1],
                        FirstName = sdr[2].ToString(),
                        LastName = sdr[3].ToString(),
                        Gender = sdr[4].ToString(),
                        //DateOfBirth = sdr[5].ToString(),
                        ContactNumber = Convert.ToInt64(sdr[5]),
                        EmailId = sdr[6].ToString(),
                        City = sdr[7].ToString(),
                        State = sdr[8].ToString(),
                        Country = sdr[9].ToString(),
                        Picture=sdr[10].ToString()
                    };
                    lstcon.Add(contact);
                }
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
            //Return the record value
            return lstcon;
        }
        /// <summary>
        /// this method is for editing existing contact and get as Updated contact
        /// </summary>
        /// <param name="contact"></param>
        public void UpdateContactById(Contact contact)
        {
            try
            {
                //Update Contact By Id
                cmd = new SqlCommand();
                cmd.CommandText = "update Contact set ContactId=@ci,CategoryId=@catid,FirstName=@fname,LastName=@lname,Gender=@gen,ContactNumber=@pn,EmailId=@eid,City=@c,State=@st,Country=@co,Picture=@pic where ContactId=@ci";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ci", contact.ContactId);
                cmd.Parameters.AddWithValue("@catid", contact.CategoryId);
                cmd.Parameters.AddWithValue("@fname", contact.FirstName);
                cmd.Parameters.AddWithValue("@lname", contact.LastName);
                cmd.Parameters.AddWithValue("@gen", contact.Gender);
                cmd.Parameters.AddWithValue("@pn", contact.ContactNumber);
                cmd.Parameters.AddWithValue("@eid", contact.EmailId);
                cmd.Parameters.AddWithValue("@c", contact.City);
                cmd.Parameters.AddWithValue("@st", contact.State);
                cmd.Parameters.AddWithValue("@co", contact.Country);
                cmd.Parameters.AddWithValue("@pic", contact.Picture);
                con.Open();
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PbException("ContactId does not exist");
                }
            }
            catch (SqlException ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("some error has happened" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// this method is for editing existing category and get as Updated category
        /// </summary>
        /// <param name="category"></param>
        public void UpdateCategoryById(Category category)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "update Category set CategoryId=@catid,CategoryName=@catname where CategoryId=@ci";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@catid", category.CategoryId);
                cmd.Parameters.AddWithValue("@ci", category.CategoryName);
                con.Open();
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PbException("Could not update category");
                }
            }
            catch (SqlException ex)
            {
                throw new PbException("Some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PbException("Some error has happened" + ex.Message);
            }
        }
    }
}
