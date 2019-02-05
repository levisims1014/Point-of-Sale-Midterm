using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    class Calculations
    {
        PaymentType obj = new PaymentType();
        //double money = obj.Cash();
        public double subtotal;
        public double salesTax;
        public double grandTotal;
        public double cashAmount;
        public double changeCash;
        public List<orderedItemInfo> orderedItems = new List<orderedItemInfo>();
        public Calculations(List<orderedItemInfo> orderedItems)
        {
            this.orderedItems = orderedItems;
            Totals();
        }
        
        public void Totals() //change to public static int Totals (pass in list) return 
        {
            List<double> costs = new List<double>();
            subtotal = 0;
            salesTax = 0.06; //Michigan sales tax is 6%.
            grandTotal = 0;

            foreach (orderedItemInfo item in orderedItems)
            {
                subtotal = item.Price * item.Quantity;              
                
                costs.Add(subtotal);
            }
            double sum = costs.Sum();
            //Console.WriteLine("Subtotal = " + sum);//transfer to receipt view
            salesTax = Math.Round(costs.Sum() * salesTax,2);
            grandTotal = salesTax + sum;
          
        }
        

        public bool EnoughFunds(double cashAmount)
        {
            if (cashAmount < grandTotal)
            {
                return false;
            }
            else
            {
                changeCash =cashAmount - grandTotal;
                this.cashAmount = cashAmount;
                return true;
            }
        }
    }
}
