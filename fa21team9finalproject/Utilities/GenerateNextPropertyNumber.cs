using fa21team9finalproject.DAL;
using System;
using System.Linq;

namespace fa21team9finalproject.Utilities
{
    public static class GenerateNextPropertyNumber
    {
        public static Int32 GetNextPropertyNumber(AppDbContext _context)
        {
            //set a constant to designate where the property id numbers 
            //should start
            // TODO: set start number
            const Int32 START_NUMBER = 3000;

            Int32 intMaxPropertyNumber; //the current maximum property ID number
            Int32 intNextPropertyNumber; //the order number for the next property ID

            if (_context.Properties.Count() == 0) //there are no orders in the database yet
            {
                intMaxPropertyNumber = START_NUMBER; //Property IDs start at 3000
            }

            else
            {
                intMaxPropertyNumber = _context.Properties.Max(p => p.PropertyNumber); //this is the highest number in the database right now
            }

            //You added records to the database before you realized 
            //that you needed this and now you have numbers less than 3000 
            //in the database
            if (intMaxPropertyNumber < START_NUMBER)
            {
                intMaxPropertyNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextPropertyNumber = intMaxPropertyNumber + 1;

            //return the value
            return intNextPropertyNumber;
        }

    }
}