using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    class Receipt
    {
        List<orderedItemInfo> orderedList = new List<orderedItemInfo>(); 
        public Receipt(List<orderedItemInfo> orderedItems)
        {
            this.orderedList = orderedItems;
        }

        // At the end, display a receipt with all items ordered, subtotal, grand total, and
        //appropriate payment info.

        public void DisplayReceript()
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
                order = string.Format("{0,-40} {1,-40} {2,-40}", orderedItem.Name, orderedItem.Quantity, orderedItem.Price);
                Console.WriteLine(order);
            }

            DateTime today = DateTime.Today;
            Console.WriteLine(today);


        }
    }
}
