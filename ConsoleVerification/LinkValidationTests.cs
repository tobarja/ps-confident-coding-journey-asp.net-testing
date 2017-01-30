using ForgetTheMilk.BusinessLogic;
using NUnit.Framework;

namespace ConsoleVerification
{
    class LinkValidationTests : AssertionHelper
    {
        [Test]
        public void Validate_InvalidUrl_ThrowsException()
        {
            var invalidLink = "http://www.doesnotexistdotcom.com";

            Expect(() => new LinkValidator().Validate(invalidLink),
                Throws.Exception.With.Message.EqualTo("Invalid link " + invalidLink));
        }

        [Test]
        public void Validate_ValidUrl_DoesNotThrowException()
        {
            var invalidLink = "http://www.google.com";

            Expect(() => new LinkValidator().Validate(invalidLink),
                Throws.Nothing);
        }
    }
}
