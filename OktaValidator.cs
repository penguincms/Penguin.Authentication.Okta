﻿using Penguin.Web;

namespace Penguin.Authentication.Okta
{
    public class OktaValidator
    {
        public string SubDomain { get; private set; }

        public OktaValidator(string oktaSubDomain)
        {
            SubDomain = oktaSubDomain;
        }

        public bool Validate(string username, string password)
        {
            return Validate(SubDomain, username, password);
        }

        public static bool Validate(string oktaSubDomain, string username, string password)
        {
#if NETFRAMEWORK
            if (!ServicePointManager.SecurityProtocol.HasFlag(SecurityProtocolType.Tls12))
            {
                throw new SecurityException($"{nameof(ServicePointManager)}.{nameof(ServicePointManager.SecurityProtocol)} must have flag {nameof(SecurityProtocolType)}.{nameof(SecurityProtocolType.Tls12)} ({(int)SecurityProtocolType.Tls12}) set in order to connect to OKTA service");
            }
#endif
            OktaRequest request = new()
            {
                Options = new LoginOptions()
                {
                    WarnBeforePasswordExpired = true,
                    MultiOptionalFactorEnroll = true
                },
                Username = username,
                Password = password
            };

            using JsonClient jc = new();

            OktaResponse response = jc.UploadJson<OktaResponse>($"https://{oktaSubDomain}.okta.com/api/v1/authn", request);

            return response.Status == "SUCCESS";
        }
    }
}