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
            int i = 0;
            string s = string.Format("{0,-4}{1,-40} {2,-30} {3, -40} {4, -20}", "","Name", "Category", "Description", "Price");

            ConsoleColor color = ConsoleColor.DarkRed;
            Console.ForegroundColor = color;

            Console.WriteLine(s);

            foreach (ItemInformation item in Items)
            {
                string b= string.Format("{0,-4}{1,-40} {2,-30} {3, -40} {4, -20}", i+1 + ".)", item.Name, item.Category, item.Description, item.Price);
                ConsoleColor coloor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = coloor;
                Console.WriteLine(b);
                i++;
            }
        }
    }
}
 