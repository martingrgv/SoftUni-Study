using Newtonsoft.Json;

namespace ProductShop;

[JsonObject]
public class UserSoldProductsDTO
{
    [JsonProperty("firstName")]
    public string FirstName { get; set; } = null!;

    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;

    [JsonProperty("soldProducts")]
    public ICollection<SoldProductDTO> SoldProducts { get; set; } = new List<SoldProductDTO>();
}

public class SoldProductDTO
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("price")]
    public decimal Price { get; set; }
    
    [JsonProperty("buyerFirstName")]
    public string BuyerFirstName { get; set; } = null!;

    [JsonProperty("buyerLastName")]
    public string BuyerLastName { get; set; } = null!;
}
