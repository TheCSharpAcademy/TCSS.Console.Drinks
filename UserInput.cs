using Spectre.Console;
using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class UserInput
{
    internal void GetCategoriesInput()
    {
        var drinksService = new DrinksService();
        var availableCategories = drinksService.GetCategories();

        var categorySelector = new SelectionPrompt<string>();
        categorySelector.Title("Select the category you wish to view");
        categorySelector.AddChoices(availableCategories);

        var categorySelected = AnsiConsole.Prompt(categorySelector);
    }
}
