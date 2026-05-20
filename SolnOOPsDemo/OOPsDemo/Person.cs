using System;
using System.Collections.Generic;
using System.Linq;
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

        public string FirstName {
            get {
                return _FirstName;
            }
            set {

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
            get {
                return LastName + ", " + FirstName;
            }
        }

        public Residentaddress Address { get; set; }
        public List<Employment> Employmentpositions {  get; set; }
        //methods

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";
            Employmentpositions = new List<Employment>();
        }

    }
}
