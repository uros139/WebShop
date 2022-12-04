using System.Text.Json.Serialization;

namespace Enigmatry.Shop.Api.Dto;

public class ArticleDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Price")]
    public int Price { get; set; }
    public bool IsSold { get; set; }
    [JsonIgnore]
    public DateTime SoldDate { get; set; }
    public int BuyerUserId { get; set; }
}
