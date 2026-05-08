using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDemo
{
    public class Employment
    {
        // data members
        #region datamembers

        //data members (aka fields, variables, attributes)
        //typically data members are private and hold data for use
        //  within your class
        //usually associated with a property
        //a data member does not have any built-in validation
        private string _Title;
        private double _Years;
        private SupervisoryLevel _Level;

        #endregion


        #region properties
        //Properties
        //are associated with a single piece of data.
        //Properties can be implemented by:
        //  a) fully implemented property
        //  b) auto implemented property

        //A property does not need to store data
        //  this type of property is referred to as a read-only
        //  this property typically uses existing data values
        //      within the instance to return a computed value

        //fully implemented properties usually has additional logic
        //  to execute for control over the data: such as validation
        //fully implemented properties will have a declared data
        //  member to store the data into

        //auto implemented properties do not have additional logic
        //Auto implemented properties do not have a declared
        //  data member instead the o/s will create on the property's
        //  behave a storage that is accessable ONLY by the property

        ///<summary>
        ///Property: Title
        ///datatype: string
        ///validation: there must be a character in the string
        ///a property will always have a getter (accessor)
        ///a property may or maynot have a setter (mutator)
        /// no mutator the property is consider "read-only" and is
        ///         usually returning a computed field
        /// has a mutator, the property will at some point save the data
        ///     to storage
        /// the mutator may be public (default) or private
        ///     public: accessable by outside users of the class
        ///     private: accessable ONLY within the class, usually
        ///                 via the constructor or a method
        /// !!!!! a property DOES NOT have ANY declared incoming parameters !!!!!!
        /// </summary>
        /// 


        public string Title
        {
            //accessor (getter)
            //returns the string associated with this property
            get { return _Title; }
            set
            {
                // add valication check
                // check for the value should not be empty , null, whitespaces

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title", "Title cannot be empty or just blanks");
                }
                else
                {
                    _Title = value;
                }
            }

        }

        public double Year
        {
            get { return _Years; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"the years of experience :{value} can not be zero or negative");
                }
                else
                {
                    _Years = value;
                }

            }
        }

        public SupervisoryLevel Level
        { 
            get { return _Level; }
            set { _Level = value; }
        
        }


        public DateTime StartDate // autoimplimented property
        {
            get;
            set;
        
        }

        #endregion
        // methods

        #region methods

        Employment()
        {
            // default intital values

            Title = "unknown";
            Year = 0.0;
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;

        }
        //Employment(string Title, double Year);

        Employment(string title, SupervisoryLevel level, DateTime startdate, double year)
        {
            Title = title;
            Year = year;
            Level = level;
            StartDate = startdate;
        }



        public void Display_Employment()
        {  }

        #endregion

    }
}
