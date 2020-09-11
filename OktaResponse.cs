using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Penguin.Authentication.Okta
{
    public class Cancel
    {
        [JsonProperty("hints")]
        public Hints Hints { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class Hints
    {
        [JsonProperty("allow")]
        public List<string> Allow { get; set; }
    }

    public class Links
    {
        [JsonProperty("cancel")]
        public Cancel Cancel { get; set; }
    }

    public class OktaResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("sessionToken")]
        public string SessionToken { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Profile
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}