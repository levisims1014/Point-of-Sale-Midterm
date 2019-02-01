using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    class Calculations
    {

        double itemTotal = 0;
        List<orderedItemInfo> orderedItems = new List<orderedItemInfo>();
        public Calculations(List<orderedItemInfo> orderedItems)
        {
            this.orderedItems = orderedItems;
        }
        //ItemInformation(string name, string category, string description, double price
        public void Totals()
        {
            List<double> costs = new List<double>();
            double itemTotal = 0;
            double subtotal = 0;
            double salesTax = 0;
            double grandTotal = 0;
            double Price;
            int Quantity;
            foreach (orderedItemInfo item in orderedItems)
            {
                subtotal = item.Price * item.Quantity;
                costs.Add(subtotal);
            }
            Console.WriteLine(costs.Sum());


        }
    }
}
