using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    class Receipt
    {
        Calculations calculation ;
        List<orderedItemInfo> orderedList; 
        public Receipt( Calculations calculation)
        {
            this.calculation = calculation;
            //this.orderedList = calculation.orderedItems;
            orderedList = new List<orderedItemInfo>(calculation.orderedItems);
        }

        // At the end, display a receipt with all items ordered, subtotal, grand total, and
        //appropriate payment info.

        public void DisplayReceript(string paymentType)
        {
            ConsoleColor color = ConsoleColor.DarkRed;
            Console.ForegroundColor = color;
            string s = string.Format("{0,100}", "********TRANSACTION RECORD********");
            Console.WriteLine(s);
             color = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = color;
            string order = string.Format("{0,-40} {1,-40} {2,-40}", "Name", "Quantity", "Price per item");
            Console.WriteLine(order);
            color = ConsoleColor.Blue;
            Console.ForegroundColor = color;
            foreach (orderedItemInfo orderedItem in orderedList)
            {
                order = string.Format("{0,-40} {1,-40} {2,-40}", orderedItem.Name, orderedItem.Quantity, "$"+orderedItem.Price);
                Console.WriteLine(order);
            }
            Console.WriteLine();
            Console.WriteLine("Sales Tax: "+"$"+ calculation.salesTax);
            Console.WriteLine("Grand Total: " + "$"+calculation.grandTotal);
            Console.WriteLine("Paid with " +"$"+ paymentType);
            if (paymentType == "Cash")
            {
                Console.WriteLine("Paid: " +"$"+calculation.cashAmount);
                Console.WriteLine("Change: " +"$"+ calculation.changeCash);
            }
            else
            {
                Console.WriteLine("Paid " +"$"+ calculation.grandTotal);
            }           
            
            DateTime today = DateTime.Now;
            Console.WriteLine(today);


        }
    }
}
