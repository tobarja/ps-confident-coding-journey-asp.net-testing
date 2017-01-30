using ForgetTheMilk.BusinessLogic;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ForgetTheMilk.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Link { get; set; }

        public Task(string task, DateTime today, ILinkValidator linkValidator = null)
        {
            Description = task;
            var dueDatePattern = new Regex(@"(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)\s(\d{1,2})");
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var monthInput = dueDate.Groups[1].Value;
                var month = DateTime.ParseExact(monthInput, "MMM", CultureInfo.CurrentCulture).Month;
                var day = Convert.ToInt32(dueDate.Groups[2].Value);
                var year = today.Year;
                var shouldWrapYear = month < today.Month || (month == today.Month && day < today.Day);
                if (shouldWrapYear)
                {
                    year++;
                }
                if (day <= DateTime.DaysInMonth(year, month))
                {
                    DueDate = new DateTime(year, month, day);
                }
            }

            var linkPattern = new Regex(@"(http://[^\s]+)");
            var hasLink = linkPattern.IsMatch(task);
            if (hasLink)
            {
                var link = linkPattern.Match(task).Groups[1].Value;
                if (linkValidator != null)
                {
                    linkValidator.Validate(link);
                }
                Link = link;
            }
        }
    }
}