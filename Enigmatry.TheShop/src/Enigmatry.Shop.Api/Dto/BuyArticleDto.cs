using System.Text.Json.Serialization;

namespace Enigmatry.Shop.Api.Dto;

public class BuyArticleDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("price")]
    public int Price { get; set; }
}