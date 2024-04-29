using Newtonsoft.Json;
using System.Net.Http.Headers;
using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class DrinksService
{
    public static async Task<List<Category>> GetCategories()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await httpClient.GetAsync("list.php?c=list");

        if (!response.IsSuccessStatusCode)
            return new List<Category>();

        string rawResponse = await response.Content.ReadAsStringAsync();
        var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

        return serialize.CategoriesList;
    }
}
