using System;
using System.Text.RegularExpressions;

namespace ForgetTheMilk.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Task(string task, DateTime today)
        {
            Description = task;
            var dueDatePattern = new Regex(@"may\s(\d)");
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var day = Convert.ToInt32(dueDate.Groups[1].Value);
                DueDate = new DateTime(today.Year, 5, day);
                if (DueDate < today)
                {
                    DueDate = DueDate.Value.AddYears(1);
                }
            }
        }
    }
}