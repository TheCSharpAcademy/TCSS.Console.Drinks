using Newtonsoft.Json;
using System.Net.Http.Headers;
using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class DrinksService
{
    public async Task<List<string>> GetCategories()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await httpClient.GetAsync("list.php?c=list");

        if (!response.IsSuccessStatusCode)
            return new List<string>();

        string rawResponse = await response.Content.ReadAsStringAsync();
        var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

        return serialize.CategoriesList.Select(x => x.strCategory).ToList();
    }

    public async Task<List<Drink>> GetDrinksByCategory(string category)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await httpClient.GetAsync($"filter.php?c={category}");

        if (!response.IsSuccessStatusCode)
            return new List<Drink>();

        string rawResponse = await response.Content.ReadAsStringAsync();
        var serialize = JsonConvert.DeserializeObject<Models.Drinks>(rawResponse);

        return serialize.DrinksList;
    }
}
