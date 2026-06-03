using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDemo
{
    public static class Utilities
    {
        //static classes are NOT instantiated by the outside user (developer/code)
        //static class items are referenced using:  classname.xxxx
        //methods within this class have the keyword static in their signature
        //static classes are shared between all outside users at the same time
        //DO NOT consider saving data within a static class BECAUSE you cannot be
        //  certain it will be there when you use the class again
        //consider placing GENERIC re-usable methods with a static class

        //sample of a generic methods: will test numerics for a value of zero or more (positive zero value)

        public static bool IsZeroOrPositive(double value)
        {
            // use flags to set the status of value 

            bool valid = true; // // this method assumes that the value is correct

            if (value < 0.0)
                valid = false;
            else
                valid = true;

            return valid;
        }

        public static bool IsZeroOrPositive(int value)
        {
            // use flags to set the status of value 

            bool valid = true; // // this method assumes that the value is correct

            if (value < 0)
                valid = false;
            else
                valid = true;

            return valid;
        }

        public static bool IsZeroOrPositive(decimal value)
        {
            // use flags to set the status of value 

            bool valid = true; // // this method assumes that the value is correct

            if (value < 0.0m)
                valid = false;
            else
                valid = true;

            return valid;
        }

        
    }
}
