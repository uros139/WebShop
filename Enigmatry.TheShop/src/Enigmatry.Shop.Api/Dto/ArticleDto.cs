using System.Text.Json.Serialization;

namespace Enigmatry.Shop.Api.Dto;

public class ArticleDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("price")]
    public int Price { get; set; }
}
