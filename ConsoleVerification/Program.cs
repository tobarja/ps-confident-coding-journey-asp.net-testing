using ForgetTheMilk.Models;
using System;

namespace ConsoleVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Pickup the groceries";
            var task = new Task(input);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Due Date: " + task.DueDate);
            Console.WriteLine();

            input = "Pickup the groceries may 5";
            task = new Task(input);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Due Date: " + task.DueDate);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
