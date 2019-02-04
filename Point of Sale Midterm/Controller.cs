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
        MenuView obj;

        public Controller()
        {
            menu.Add(new ItemInformation("Hot Chocolate", "Hot Beverage", "Milk, Cocoa, Sugar, Fat", 1.99));
            menu.Add(new ItemInformation("Latte", "Hot Beverage", "Milk, Coffee", 1.99));
            menu.Add(new ItemInformation("Coffee", "Hot Beverage", "Coffee, Water", 1.00));
            menu.Add(new ItemInformation("Tea", "Hot Beverage", "Black Tea", 1.00));
            menu.Add(new ItemInformation("Frozen Lemonade", "Cold Beverage", "Lemon, Sugar, Ice", 1.99));
            menu.Add(new ItemInformation("Breakfast Wrap", "Breakfast", "Bread,Potatoes,Eggs", 3.00));
            menu.Add(new ItemInformation("Sauasage Muffin", "Breakfast", "Biscuit,Sausage,Egg,Cheese", 3.00));
            menu.Add(new ItemInformation("Donuts", "Dessert", "Sugar,Bread,Oil,Butter", 0.50));
            menu.Add(new ItemInformation("Chicken and Mozzarella Panini", "Lunch", "Chicken,Mozzarella,Bread", 3.00));
            menu.Add(new ItemInformation("Crispy Chicken Sandwich", "Lunch", "Chicken,Bread,Lettuce,Tomato", 3.00));
            menu.Add(new ItemInformation("Parfait", "Dessert", "Yogurt,Berries,Granola", 1.99));
            menu.Add(new ItemInformation("Bagel", "Breakfast", "Bread,Cream Cheese", 1.99));

            obj = new MenuView(menu);
            obj.DisplayMenu();
             Order();

        }
        public void Order()
        {
            List<orderedItemInfo> orderedItems = new List<orderedItemInfo>();//list of ordered items
            bool orderAgain = true;
            while (orderAgain)
            {
                int quantityPerItem = 0;
                int choice;
                //Present a menu to the user and let them choose an item(by number orletter).
                ConsoleColor color = ConsoleColor.Blue;
                Console.ForegroundColor = color;
                Console.WriteLine("What would you like to order?");
                Console.WriteLine();
                Console.WriteLine("Please choose an item by a number or by a name:");
                var userInput = Console.ReadLine(); // I used(var) because We dont know if the user will enter a number or a string
                bool gotValue = int.TryParse(userInput, out choice);
                if (gotValue == true) //that mean the user choosed  an item from the menu by it's number
                {
                    //there are 12 items in the menu (the number should be 1 >= 1 and numbe <= 12 )
                    if (choice >= 1 && choice <= 12)
                    {
                    // Allow the user to choose a quantity for the ordered item.
                    QuentityCheck:
                        {
                            color = ConsoleColor.Blue;
                            Console.ForegroundColor = color;
                            Console.WriteLine("Please enter the quantity: ");
                            bool gotQuanttity = int.TryParse(Console.ReadLine(), out quantityPerItem);
                            if (gotQuanttity == false)//if the  user didn't enter a number
                            {
                                color = ConsoleColor.DarkRed;
                                Console.ForegroundColor = color;
                                Console.WriteLine("you entered unvalid number for quantity!!");
                                goto QuentityCheck;// give the user a nother chance to choose a valid number for quantity
                            }
                        }
                        orderedItems.Add(new orderedItemInfo(menu[choice -1].Name , menu[choice-1].Price, quantityPerItem));
                    }
                    else//the user entered a number that is not in the list
                        {
                            color = ConsoleColor.DarkRed;
                            Console.ForegroundColor = color;
                            Console.WriteLine("This number is not in the menu!!");
                                continue;// give the user a nother chance to choose from the menu
                        }
                }
                else // that mean the user choosed an item from the menu by it's name
                {
                        // check if the item name is in the menu
                        bool findItem = false;
                         double pricePerItem =0;
                        foreach (ItemInformation s in menu)
                        {
                             if (userInput == s.Name)
                            {
                                findItem = true;//the item is in the menu
                                pricePerItem = s.Price;
                            }
                        }
                    if (findItem == true)
                    {
                    quantityCheck:
                        {
                            color = ConsoleColor.Blue;
                            Console.ForegroundColor = color;
                            Console.WriteLine("Please enter the quantity: ");
                            bool gotQuanttity = int.TryParse(Console.ReadLine(), out quantityPerItem);
                            if (gotQuanttity == false)//if the  user didn't enter a number ex string or a character
                            {
                                color = ConsoleColor.DarkRed;
                                Console.ForegroundColor = color;
                                Console.WriteLine("you entered unvalid number for quantity!!");
                                goto quantityCheck;// give the user a nother chance to choose a valid number for quantity
                            }
                            orderedItems.Add(new orderedItemInfo(userInput, pricePerItem, quantityPerItem));
                        }
                    }


                    else if (findItem == false)// we don't have this iteam in the menu
                    {
                        color = ConsoleColor.DarkRed;
                        Console.ForegroundColor = color;
                        Console.WriteLine("Sorry we don't have " + userInput);
                        Console.WriteLine("Please try again");
                        continue;
                    }
                }
            repeatTheorder:
                {
                    color = ConsoleColor.Blue;
                    Console.ForegroundColor = color;
                    Console.WriteLine("would like to order any more items (yes/no)?");
                    string repeat = Console.ReadLine().ToLower();
                    if (repeat == "no")
                    {
                        // when the user finish his order we are going to calculate the total,tax,then printing the receipt
                       Calculations obj = new Calculations(orderedItems);
                       obj.Totals();
                       Receipt receipt = new Receipt(orderedItems);
                        receipt.DisplayReceript();
                        break; // exit the loop
                    }
                    if (repeat == "yes")
                    {
                        obj.DisplayMenu();
                        continue;
                    }
                    else
                    {
                        color = ConsoleColor.DarkRed;
                        Console.ForegroundColor = color;
                        Console.WriteLine("Sorry your choice was not clear!!");
                        goto repeatTheorder;
                    }
                }

            }

        }
    }
}
