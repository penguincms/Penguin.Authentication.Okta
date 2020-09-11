using Penguin.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Penguin.Authentication.Okta
{
    public static class OktaValidator
    {
        public static bool Validate(string domain, string username, string password)
        {
            OktaRequest request = new OktaRequest()
            {
                Options = new LoginOptions()
                {
                    WarnBeforePasswordExpired = true,
                    MultiOptionalFactorEnroll = true
                },
                Username = username,
                Password = password
            };

            JsonClient jc = new JsonClient();

            OktaResponse response = jc.UploadJson<OktaResponse>($"https://{domain}.okta.com/api/v1/authn", request);

            return response.Status == "SUCCESS";
        }
     
    }
}
