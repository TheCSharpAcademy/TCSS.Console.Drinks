using Spectre.Console;
using TCss.Console.Drinks.Helpers;
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

        var drink = AnsiConsole.Prompt(drinkSelector);

        await ShowDrink(drink);

    }

    private async Task ShowDrink(Drink drink)
    {
        var drinksService = new DrinksService();
        var drinkSelected = await drinksService.GetDrink(drink);

        Table details = TableVisualisation.ShowTable(drinkSelected);

        AnsiConsole.Write(details);

        ExitProgram();
    }

    private static void ExitProgram()
    {
        if (!AnsiConsole.Confirm("Press enter to continue"))
            Environment.Exit(1);
    }
}
