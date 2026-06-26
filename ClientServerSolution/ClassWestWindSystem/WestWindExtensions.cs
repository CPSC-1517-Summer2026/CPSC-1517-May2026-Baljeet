using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// refer to additional Namespaces

using ClassWestWindSystem.BLL;
using ClassWestWindSystem.DAL;
using ClassWestWindSystem.Entity;

namespace ClassWestWindSystem
{
    public static class WestWindExtensions
    {
        // setup the extension method for this library
        public static void WWExtensions(this.IServiceCollection services,  
                                        Action <DbContextOptionsBuilder> options)
        {
            // we will register all our services that will be available for use
            // by any system 
            // Services will coded in BLL 

            // DbContectConnection
            // we will register the BB connection to be used by any service requiring access to the database

            // Register the context service
            // the parmeter options contain the connection string information

            services.AddDbContext<WestWindContext>(options);

            //Register your service


            services.AddTransient<BuildVersion>((ServiceProvider) =>
            {
                // get the context of class that was registered above

                var context = ServiceProvider.GetService<WestWindContext>();

            });

        }

       
    }
}
