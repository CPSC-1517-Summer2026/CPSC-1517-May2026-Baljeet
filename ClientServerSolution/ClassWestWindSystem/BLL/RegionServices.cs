using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;



namespace ClassWestWindSystem.BLL
{
    public class RegionServices
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

        internal RegionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;

        }

        #endregion


        // methods 

        // method name - entityname_methodtio impliment

        public List<Region> Region_GetList()
        {

            IEnumerable<Region> info = _context.Regions.OrderBy(r => r.RegionDescription);

            return info.ToList();
        }

        // get details of region by specific ID

        public Region Region_GetByID(int regionID)
        {
            Region info = null; 

            info = _context.Regions.Where(r => r.RegionId == regionID).FirstOrDefault();

            return info;
        }






    }
}
