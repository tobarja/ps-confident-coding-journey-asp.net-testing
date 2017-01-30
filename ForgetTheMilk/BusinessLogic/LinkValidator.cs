using System;
using System.Net;

namespace ForgetTheMilk.BusinessLogic
{
    public class LinkValidator : ILinkValidator
    {
        public void Validate(string link)
        {
            var request = WebRequest.CreateHttp(link);
            request.Method = "HEAD";
            try
            {
                request.GetResponse();
            }
            catch (WebException)
            {
                throw new ApplicationException("Invalid link " + link);
            }
        }
    }
}