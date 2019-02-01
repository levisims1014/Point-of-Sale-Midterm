using System;
namespace Point_of_Sale_Midterm
{
    public class orderedItemInfo
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public orderedItemInfo(string name,double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}


