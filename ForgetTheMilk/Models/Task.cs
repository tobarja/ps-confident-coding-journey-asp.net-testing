using System;
using System.Text.RegularExpressions;

namespace ForgetTheMilk.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Task(string task)
        {
            Description = task;
            var dueDatePattern = new Regex(@"may\s(\d)");
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var day = Convert.ToInt32(dueDate.Groups[1].Value);
                DueDate = new DateTime(DateTime.Today.Year, 5, day);
            }
        }
    }
}