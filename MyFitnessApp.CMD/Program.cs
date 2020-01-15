using MyFitnessApp.BL.Controller;
using System;

namespace MyFitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is fitness application");

            Console.WriteLine("Please enter users name");
            var name = Console.ReadLine();
            
            var usersController = new UserController(name);

            if (usersController.IsUserNew)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();
                var birthday = ParseBirthdayDate();
                var height = ParseDouble("height");
                var weight = ParseDouble("weight");

                usersController.SetNewUser(gender, birthday, height, weight);
            }
            Console.WriteLine(usersController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseBirthdayDate()
        {
            DateTime birthday;
            while (true)
            {
                Console.WriteLine("Enter your bithday: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date format of birthday date");
                }
            }

            return birthday;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter your {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong format of {name}");
                }
            }
        }
    }
}
