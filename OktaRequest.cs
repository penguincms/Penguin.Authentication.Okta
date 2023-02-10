using Newtonsoft.Json;

namespace Penguin.Authentication.Okta
{
    public class LoginOptions
    {
        [JsonProperty("warnBeforePasswordExpired")]
        public bool WarnBeforePasswordExpired { get; set; }

        [JsonProperty("multiOptionalFactorEnroll")]
        public bool MultiOptionalFactorEnroll { get; set; }
    }

    internal class OktaRequest
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("options")]
        public LoginOptions Options { get; set; }
    }
}