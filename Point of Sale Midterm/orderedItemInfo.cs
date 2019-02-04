using System;
namespace Point_of_Sale_Midterm
{
    public class orderedItemInfo
    {
        private string name;
        public string Name { get { return name; }}
        private double price;
        public double Price { get { return price; } }
        public int Quantity { get; set; }
        public orderedItemInfo(string name,double price, int quantity)
        {
            this.name= name;
            this.price = price;
            this.Quantity = quantity;
        }

    }
}


