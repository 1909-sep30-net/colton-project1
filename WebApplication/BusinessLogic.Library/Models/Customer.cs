using System;
using System.Linq;

namespace BusinessLogic.Library
{
    /// <summary>
    /// A class of customers with first and last names and Id's
    /// </summary>
    public class Customer
    {
        private string _fname;
        private string _lname;
        public int Id { get; set; }


        public string FirstName
        {
            get => _fname;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First Name must not be empty", nameof(value));
                }
                _fname = value;
            }
        }
        public string LastName
        {
            get => _lname;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last Name must not be empty", nameof(value));
                }
                _lname = value;
            }
        }



    }

}
