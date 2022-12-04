using System.Text.Json.Serialization;

namespace Enigmatry.Vendor.Models;

public class Article
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("isSold")]
    public bool IsSold { get; set; }

    [JsonPropertyName("soldDate")]
    public DateTimeOffset? SoldDate { get; set; }

    [JsonPropertyName("buyerUserId")]
    public int BuyerUserId { get; set; }
}