using ForgetTheMilk.BusinessLogic;
using ForgetTheMilk.Models;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    class TaskLinkTests : AssertionHelper
    {
        class IgnoreLinkValidator : ILinkValidator
        {
            public void Validate(string link)
            {
            }
        }

        class AlwaysThrowsValidator : ILinkValidator
        {
            public void Validate(string link)
            {
                throw new ApplicationException("Invalid link " + link);
            }
        }

        [Test]
        public void CreateTask_DescriptionWithALink_SetLink()
        {
            var input = "test http://www.google.com";

            var task = new Task(input, default(DateTime), new IgnoreLinkValidator());

            Expect(task.Link, Is.EqualTo("http://www.google.com"));
        }

        [Test]
        public void CreateTask_WithInvalidLink_ThrowsException()
        {
            var input = "http://doesnotexistdotcom.com";

            Expect(() => new Task(input, default(DateTime), new AlwaysThrowsValidator()),
                Throws.Exception.With.Message.EqualTo("Invalid link " + input));
        }
    }
}
