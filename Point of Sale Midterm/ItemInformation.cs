using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    public class ItemInformation
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public  int Counter { get; set; }
         

        public ItemInformation(string name, string category, string description, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Price = price;
            Counter++;
        }
    }
}
