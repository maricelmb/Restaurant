﻿namespace Restaurant.Services.AuthAPI.Models
{
    public class JWTOptions
    {
        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string Secret { get; set; } = string.Empty;
    }
}
