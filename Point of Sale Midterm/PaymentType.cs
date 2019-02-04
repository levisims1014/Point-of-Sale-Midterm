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
                else if (input >= 1 && input <= 3)
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
        public void Check()
        {
            Regex routing = new Regex("^[0-9]{8,10}$");
            Regex account = new Regex("^[0-9]{10,17}$");

            Console.WriteLine("Please enter in your routing number.(8-10 digits)");
            string userRouting = Console.ReadLine();

            Match validRouting = routing.Match(userRouting);
            if (validRouting.Success)
            {
                Console.WriteLine("Please enter in your account number. (10-17 digits) ");
                string userAccount = Console.ReadLine();
                Match validAccount = account.Match(userAccount);
                if (validAccount.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                    PaymentOption();
                }

            }
            else
            {
                Console.WriteLine("Invalid.");
                PaymentOption();
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
            bool checkout = true;
            while (checkout)
            {
            Console.WriteLine("Please enter your credit card number:");
            Regex cardNumber = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$");
            Regex cardExpiration = new Regex(@"^((0[1-9])|(1[0-2]))\/((2019)|(20[1-2][0-9]))$");
            Regex cardCvv = new Regex(@"^[0-9]{3,4}$");

                string creditExperition;
                string cvv;
                string creditNumber = Console.ReadLine();
                Match validateCreditNumber = cardNumber.Match(creditNumber);

                if (validateCreditNumber.Success)
                {
                    Console.WriteLine("The card number entered is vaild");
                    Console.WriteLine("Please enter the credit card expiration in the form of(MM/YYYY)");
                    creditExperition = Console.ReadLine();
                    Match expiration = cardExpiration.Match(creditExperition);
                    if (expiration.Success)
                    {
                        Console.WriteLine("valid");
                        Console.WriteLine("Please enter the credit card CVV");
                        cvv = Console.ReadLine();
                        Match validateCvv = cardCvv.Match(cvv);
                        if (validateCvv.Success)
                        {
                            Console.WriteLine("valid");
                        }
                        else
                        {
                            Console.WriteLine("That is an invalid input.");
                            PaymentOption();
                        }
                    }
                    else

                    {
                        Console.WriteLine("unvalid input ");
                        Console.WriteLine("Decline");
                        checkout = true;
                        PaymentOption();

                    }



                }
                else
                {
                    Console.WriteLine("The card number entered is unvaild");
                    PaymentOption();
                }
            }

            }
        }
    }

