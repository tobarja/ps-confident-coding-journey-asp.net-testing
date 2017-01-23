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
            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;
            Console.WriteLine("Scenario: " + input);
            if (descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("Description: " + task.Description + " should be " + descriptionShouldBe);
                Console.WriteLine("Due Date: " + task.DueDate + " should be " + dueDateShouldBe);
                Console.WriteLine("ERROR");
            }

            input = "Pickup the groceries may 5";
            task = new Task(input);
            dueDateShouldBe = new DateTime(DateTime.Today.Year, 5, 5);
            Console.WriteLine("Scenario: " + input);
            if (dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("Description: " + task.Description + " should be " + descriptionShouldBe);
                Console.WriteLine("Due Date: " + task.DueDate + " should be " + dueDateShouldBe);
                Console.WriteLine("ERROR");
            }
            Console.ReadLine();
        }
    }
}
