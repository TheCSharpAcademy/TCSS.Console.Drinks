using Spectre.Console;
using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class UserInput
{
    internal async Task GetCategoriesInput()
    {
        var drinksService = new DrinksService();
        var availableCategories = await drinksService.GetCategories();

        var categorySelector = new SelectionPrompt<string>();
        categorySelector.Title("Select the category you wish to view");
        categorySelector.AddChoices(availableCategories);

        var categorySelected = AnsiConsole.Prompt(categorySelector);

        await GetDrinksInput(categorySelected);
    }

    private async Task GetDrinksInput(string category)
    {
        var drinksService = new DrinksService();
        var availableDrinks = await drinksService.GetDrinksByCategory(category);

        var drinkSelector = new SelectionPrompt<Drink>();
        drinkSelector.Title("Select the drink you wish to view");
        drinkSelector.AddChoices(availableDrinks);
        drinkSelector.UseConverter(drink => drink.strDrink);
        drinkSelector.PageSize(25);

        AnsiConsole.Prompt(drinkSelector);
        System.Console.ReadLine();
    }
}
