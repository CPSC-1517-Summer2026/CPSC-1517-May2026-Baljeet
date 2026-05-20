using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDemo
{
    public class Person
    {
        // data members

        private string _FirstName;
        private string _LastName;

        //properties

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {

                // validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Firstname can't be empty");

                _FirstName = value;

            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {

                // validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Lasttname can't be empty");

                _LastName = value;

            }
        }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public Residentaddress Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; }
        //methods

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";
            EmploymentPositions = new List<Employment>();
        }

        public Person(string firstName, string lastName, Residentaddress address, List<Employment> employment)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            if (employment == null)
            {
                EmploymentPositions = new List<Employment>();
            }
            else
            {
                EmploymentPositions = employment;
            }
                     

        }

        public void AddEmployment(Employment employment)
        {
            if (employment == null)
                throw new ArgumentNullException("Adding Employment", "Employment required, missing employment data. Unable to add employment history. ");

            //do not care to actually receive a copy of the found instance
            //all this cares for, is there an instance that matches the condition(s)? (looking for a true or false)
            if (EmploymentPositions.Any(e => e.Title.Equals(employment.Title)
                                          && e.StartDate == employment.StartDate))
                throw new ArgumentException($"Duplicate employment. Employment record with position {employment.Title} on {employment.StartDate}");
            EmploymentPositions.Add(employment);
        }
    }
}
