using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWestWindSystem.BLL
{
    public class ShipmentServices
    {

        #region setup of the connect connection variable and the class constructor
        //this class will create an instance of the WestWindContext class
        //  everytime that a service is used by the outside user

        //any method (aka service) will probably need access to our database
        //this will be done via the context class (WestWindContext)
        //during the instantiation of this service class, we will create
        //  an instance of the context class
        //we will save this instance in a private variable usable throughout the class
        //during the instantiation of this service class the constructor will
        //  receive as a parameter of the registered connection from the IServiceCollection

        private readonly WestWindContext _context;

        internal ShipmentServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;

        }

        #endregion


        // methods 
        public List<Shipment> Shipment_GetByYearMonth(int year, int month)
        {
            // dates look like 2016-08-08
            if (year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
            }

            IEnumerable<Shipment> info = _context.Shipments.Where(s => s.ShippedDate.Year == year
                                            && s.ShippedDate.Month == month);

            return info.ToList();

        }

        // method to implement pagination
        //this method will return the data set records that are NEEDED for the current page
        //it does NOT return the entire data set collection
        //the method needs to determine the record subset to return

        public List<Shipment> Shipment_GetByYearMonthPaging(int year, int month, int currentpagenumber, int itemsperpage)
        {
             //the currentpagenumber and itemsperpage are used in the determination of which
            //  dataset record subset is to be returned from the entire dataset query collection

            // dates look like 2016-08-08
            if (year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
            }

            IEnumerable<Shipment> info = _context.Shipments.Where(s => s.ShippedDate.Year == year
                                            && s.ShippedDate.Month == month);
            // from begning you need to skip some records to display records of a specific page

            //pagination calculation logic
            //calculate the number of records to skip
            //subtract 1 from the natural page number to get the page index number

            int skippedrecords = itemsperpage * (currentpagenumber - 1);
            //return JUST the records for the current page
            //Skip: skip the first x items representing previous pages
            //Take: take up to the necessary number of items on a page

            return info.Skip(skippedrecords).Take(itemsperpage).ToList();

        }

        public int Shipment_GetByYearMonthCount(int year, int month)
        {
            // dates look like 2016-08-08
            if (year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
            }

            IEnumerable<Shipment> info = _context.Shipments.Where(s => s.ShippedDate.Year == year
                                            && s.ShippedDate.Month == month);

            return info.Count();

        }
    }
}
