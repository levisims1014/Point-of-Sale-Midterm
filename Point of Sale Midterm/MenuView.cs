using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    class MenuView
    {
        List<ItemInformation> Items = new List<ItemInformation>();
        public MenuView(List<ItemInformation> items)
        {
            this.Items = items;
            
        }
        
        public void DisplayMenu()
        {
            int i = 1;
            foreach (ItemInformation item in Items)
            {
                
                //Format To.String to Monday to get proper format
                Console.WriteLine(i +".)"+ item.Name + "\t" + item.Category + "\t" + item.Description + "\t" + item.Price);
                i++;
            }
        }
    }
}
