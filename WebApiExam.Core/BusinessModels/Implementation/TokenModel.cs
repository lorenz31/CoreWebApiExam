using Newtonsoft.Json;
using System;

namespace WebApiExam.Core.BusinessModels.Implementation
{
    public class TokenModel
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}