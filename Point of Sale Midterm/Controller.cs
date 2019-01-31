using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Midterm
{
    class Controller
    {
        List<ItemInformation> menu = new List<ItemInformation>();
        public Controller()
        {
            menu.Add(new ItemInformation("Hot Chocolate", "Hot Beverage", "Milk, Cocoa, Sugar, Fat", 1.99));
            menu.Add(new ItemInformation("Latte", "Hot Beverage", "Milk, Coffee", 1.99));
            menu.Add(new ItemInformation("Coffee", "Hot Beverage", "Coffee, Water", 1.00));
            menu.Add(new ItemInformation("Tea", "Hot Beverage", "Black Tea", 1.00));
            menu.Add(new ItemInformation("Frozen Lemonade", "Cold Beverage", "Lemon, Sugar, Ice", 1.99));
            menu.Add(new ItemInformation("Breakfast Wrap", "Breakfast", "Bread, Potatoes, Eggs", 3.00));
            menu.Add(new ItemInformation("Sauasage Muffin", "Breakfast", "Biscuit, Sausage, Egg, Cheese", 3.00));
            menu.Add(new ItemInformation("Donuts", "Dessert", "Sugar, Bread, Oil, Butter", 0.50));
            menu.Add(new ItemInformation("Chicken and Mozzarella Panini", "Lunch", "Chicken, Mozzarella, Bread", 3.00));
            menu.Add(new ItemInformation("Crispy Chicken Sandwich", "Lunch", "Chicken, Bread, Lettuce, Tomato", 3.00));
            menu.Add(new ItemInformation("Parfait", "Dessert", "Yogurt, Berries, Granola", 1.99));
            menu.Add(new ItemInformation("Bagel", "Breakfast", "Bread, Cream Cheese", 1.99));


            MenuView obj = new MenuView(menu);
            obj.DisplayMenu();
            Order();
            
        }
        public void Order()
        {
            Console.WriteLine("What would you like to order?");
            int choice;
            bool gotValue = int.TryParse(Console.ReadLine(),out choice);
            Console.WriteLine(gotValue);
        }
    }
}
