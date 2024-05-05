using Newtonsoft.Json;
using System.Net.Http.Headers;
using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class DrinksService
{
    public List<string> GetCategories()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = httpClient.GetAsync("list.php?c=list").Result;

        if (!response.IsSuccessStatusCode)
            return new List<string>();

        string rawResponse = response.Content.ReadAsStringAsync().Result;
        var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

        return serialize.CategoriesList.Select(x => x.strCategory).ToList();
    }
}
