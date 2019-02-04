using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Point_of_Sale_Midterm
{
    class PaymentType 
    {
        public PaymentType()
        {

        }
        public void PaymentOption()
        {
            
            bool run = true;
            while (run == true)
            {
                Console.WriteLine("How would you like to pay? 1.) Cash, 2.) Credit Card, or 3.) Check?");
                int input = 0;
                bool option = int.TryParse(Console.ReadLine(), out input);
                if (option == false)
                {
                    Console.WriteLine("Sorry didn't understand input!");
                    run = true;
                }
                else if(input >= 1 && input <= 3)
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("I'm sorry! That was an invalid option.");
                    run = true;
                }
                if (input == 1)
                {
                    Cash();
                }
                else if (input == 2)
                {
                    CreditCard();
                }
                else if (input == 3)
                {
                    Check();
                }
            }
        }
        public double Cash()
        {
            double input = 0;
            bool checkcash = true;
            while (checkcash == true)
            {
                Console.WriteLine("Please enter the amount of money you paying today.");
                bool checkinput = double.TryParse(Console.ReadLine(), out input);
                if (checkinput == false)
                {
                    Console.WriteLine("You entered invalid amount!");
                    checkcash = true;
                }
                else
                {
                    checkcash = false;
                }
            }
            return input;
        }
        public void CreditCard()
        {
            bool cardcheck = true;
            while (cardcheck == true)
            {
                string creditnumber;
                Console.WriteLine("Please enter your credit card number, expiration, and CVV");
                creditnumber = Console.ReadLine();
                string visa = "^ 4[0 - 9]{ 12} (?:[0 - 9]{ 3})?$";
                string mastercard = "^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$";
                if (!Regex.IsMatch(creditnumber, visa) || !Regex.IsMatch(creditnumber, mastercard))
                {
                    Console.WriteLine("Card accepted!");
                    cardcheck = false;
                }
                else
                {
                    Console.WriteLine("Card information is not valid");
                }

            }
        }
        public void Check()
        {

        }

    }
}
