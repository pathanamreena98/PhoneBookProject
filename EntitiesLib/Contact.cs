using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLib
{
    /// <summary>
    /// Contact Class
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// CategoryId from Category
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// ContactId of the person
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// First Name of the person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// last Name of the person
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gender of that person
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Contact Number of the person
        /// </summary>
        public double ContactNumber { get; set; }
        /// <summary>
        /// Email of the person
        /// </summary>
        public string EmailId { get; set; }
        /// <summary>
        /// city that person lives
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// state that person resides
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Country that person resides
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Photo of that person
        /// </summary>
        public string Picture { get; set; }
    }
}
