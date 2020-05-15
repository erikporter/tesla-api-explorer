﻿using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaAuthorization
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
    }
}
