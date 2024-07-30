using Microsoft.Identity.Client;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace CurrencyAPI.Entities
{
    public class ResponseCurrency
    {
        [JsonPropertyName("CurrencyCode")]
        public required string CurrencyCode { get; set; } 

    }
}
