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

            Console.WriteLine("Please enter date of birth");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Please enter height");
            var heightData = Double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter weight");
            var weightData = Double.Parse(Console.ReadLine());

            var usersController = new UserController(name, birthDate, gender, heightData, weightData);
            usersController.Save();
        }
    }
}
