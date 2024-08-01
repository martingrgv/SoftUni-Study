using Newtonsoft.Json;

namespace ProductShop;

public class CategoryProductDTO
{
    
    [JsonProperty("category")]
    public string CategoryName { get; set; } = null!;

    [JsonProperty("productsCount")]
    public int ProductsCount { get; set; }

    [JsonProperty("averagePrice")]
    public string ProductsAveragePrice { get; set; } = null!;


    [JsonProperty("totalRevenue")]
    public string TotalRevenue { get; set; } = null!;
}
