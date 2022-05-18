using fa21team9finalproject.DAL;
using System;
using System.Linq;

namespace fa21team9finalproject.Utilities
{
    public static class GenerateNextConfirmationNumber
    {
        public static Int32 GetNextConfirmationNumber(AppDbContext _context)
        {
            //set a constant to designate where the order numbers 
            //should start
            // TODO: set start number
            const Int32 START_NUMBER = 21900;

            Int32 intMaxConfrimationNumber; //the current maximum order number
            Int32 intNextConfrimationNumber; //the order number for the next order

            if (_context.Orders.Count() == 0) //there are no orders in the database yet
            {
                intMaxConfrimationNumber = START_NUMBER; //registration numbers start at 21900
            }
            else
            {
                intMaxConfrimationNumber = _context.Orders.Max(c => c.OrderNumber); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxConfrimationNumber < START_NUMBER)
            {
                intMaxConfrimationNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextConfrimationNumber = intMaxConfrimationNumber + 1;

            //return the value
            return intNextConfrimationNumber;
        }

    }
}