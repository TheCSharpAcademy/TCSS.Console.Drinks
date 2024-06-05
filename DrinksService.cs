using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
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

    public async Task<DrinkDetail> GetDrink(Drink drink)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await httpClient.GetAsync($"lookup.php?i={drink.idDrink}");

        if (!response.IsSuccessStatusCode) 
            return new DrinkDetail();

        string rawResponse = await response.Content.ReadAsStringAsync();
        var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

        var returnedList = serialize.DrinkDetailList;

        var drinkDetail = returnedList[0];

        return drinkDetail;
    }
}
