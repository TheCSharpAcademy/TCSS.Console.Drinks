using Spectre.Console;
using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class UserInput
{
    internal async Task GetCategoriesInput()
    {
        var availableCategories = await DrinksService.GetCategories();

        var categorySelector = new SelectionPrompt<Category>();
        categorySelector.Title("Select the category you wish to view");
        categorySelector.AddChoices(availableCategories);
        categorySelector.UseConverter(category => category.strCategory);
        categorySelector.PageSize(25);

        var categorySelected = AnsiConsole.Prompt(categorySelector);
    }
}
