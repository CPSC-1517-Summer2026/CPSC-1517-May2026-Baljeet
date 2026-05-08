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
            
        //Employment(string Title, double Year);

        //if there is no code within this constructor, the actions for setting
        //  your internal fields will be using the system defaults for the datatype

        //optionally
        // you could assign values to your initial fields within this constructor typically
        //      using literal values
        //Why?
        // your internal fields may have validation attached to the data for the field
        // this validation is usually within the property
        // you would wish to have valid data values for your internal fields

            Title = "UnKnown"; //assigned to meet validation requirements
            Level = SupervisoryLevel.TeamMember; //wish to have a different initial value
            StartDate =DateTime.Today; //a meaningful value default 0001/01/01

            //Years?
            //the default is fine (0.0)
            //however, if you wish you could actually assign the value 0 yourself
            Year = 0.0;

        }

        //Greedy
        //this is the constructor typically used to assign values to a instance at the time of
        //    creation
        //the list of parameters may or maynot contain default parameter values
        //if you have assigned default parameter values then those parameters MUST be at the end of
        //  the parameter list
        //in this example years is a default parameter (it has an assigned value if the value
        //  is not included on the coded constructor in the user program
        public Employment(string title, SupervisoryLevel level,
                            DateTime startdate, double years = 0.0)
        {
            Title = title;
            Level = level;
            //Years = years;

            //one could add valiation, especially if the property has a private set  OR the property
            //  is an auto-implemented property that has restrictions
            //example
            //validation, start date must not exist in the future
            //validation can be done anywhere in your class
            //since the property is auto-implemented AND/OR has a private set,
            //      validation can be done  in the constructor OR a behaviour 
            //      that alters the property
            //IF the validation is done in the property, IT WOULD NOT be an
            //      auto-implemented property BUT a fully-implemented property
            // .Today has a time of 00:00:00 AM
            // .Now has a specific time of day 13:05:45 PM
            //by using the .Today.AddDays(1) you cover all times on a specific date
           
             StartDate = startdate;

            //during the testing of the unit tests, it has been discovered that the number of years
            //   should also be altered to have a correct timespan
            if (years != 0.0)
            {
                Year = years;
            }
            else
            {
                if (startdate != DateTime.Today)
                {
                    TimeSpan days = DateTime.Today - startdate;
                    Year = Math.Round((days.Days / 365.2), 1);
                }
            }
        }

        public override string ToString()
        {
            //this string is known as a "comma separate value" string (csv)
            //concern: when the date is used, it could have a , within the data value
            //solution: IF this is a possibility that a value that is used in creating the string pattern
            //              could make the pattern invalid, you should explicitly handle how the value should be
            //              displayed in the string
            //example Date:  Jan 05, 2025 (due to using StartDate.ToShortDate())
            //solution:  specific your own format  StartDate.ToString("MMM dd yyyy")

            //Another solution is to change your delimitator that separates your values to a character
            //  that is not within your range of possible values
            //example use a '/'
            //when you use the .Split(delimitator) method to breakup the string into separate values
            //  you would use the delimitator '/':  string [] pieces = thestring.Split('/')

            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Year}";
        }


        public void CorrectStartDate (DateTime startdate )
        {
            if (CheckDate(startdate))
                StartDate = startdate;

            TimeSpan days = DateTime.Today - startdate;
            Year = Math.Round((days.Days / 365.2), 1);

        }


        private bool CheckDate(DateTime value)
        {
            if (value > DateTime.Today.AddDays(1))
                throw new ArgumentException($" the date {value} is not valid, start date can not be a future date");
            else
                return true;
        }
        
        public void SetEmploymentResponsibilityLevel( SupervisoryLevel newlevel)
        {
            Level = newlevel;
        }



        #endregion

    }
}
