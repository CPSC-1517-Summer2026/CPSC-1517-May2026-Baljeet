using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWestWindSystem.BLL
{
    public class CategoryServices
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

        internal CategoryServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;

        }

        #endregion
        /*********************** Services *********************************/
        public List<Category> Categories_Get()
        {
            //get the data from the Categories sql table
            IEnumerable<Category> info = _context.Categories;

            return info.OrderBy(c => c.CategoryName).ToList();
        }

    }
}
