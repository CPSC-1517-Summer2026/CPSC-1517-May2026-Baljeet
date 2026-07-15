using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWestWindSystem.BLL
{
    public class ShipperServices
    {
        // setup the context connection variable and class constructure
        // this connection will be used by all methods in this class to access the database

        private readonly WestWindContext _context;

        // constructor to be used in the creation of the instance of this class 
        // the registered reference for the context connection will be passes from the service IserviceCollection registered service


        internal ShipperServices(WestWindContext registered_context)
        {
            _context = registered_context;
        }

        // place to implement your service methods

        public List<Shipper> Shipper_ShipperShipmentList()
        {

            IEnumerable<Shipper> info = _context.Shippers.Where( // get shipper list
                                        outerShipper => _context.Shipments.Any(innerShipment => innerShipment.ShipVia == outerShipper.ShipperId)) // compare shipper list to shipments  
                                        .Distinct() // compare the results and remove the duplicates
                                        .OrderBy(x => x.CompanyName); // ordering the unique list

            return info.ToList();
        }

    }
}
