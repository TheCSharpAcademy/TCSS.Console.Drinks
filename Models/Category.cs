using Newtonsoft.Json;

namespace TCSS.Console.Drinks.Models;

public class Category
{
    public string strCategory { get; set; }
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}
