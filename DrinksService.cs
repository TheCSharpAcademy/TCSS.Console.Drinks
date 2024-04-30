using TCSS.Console.Drinks.Models;

namespace TCSS.Console.Drinks;

internal class DrinksService
{
    public List<string> GetCategories()
    {
        var categories = new Categories
        {
            CategoriesList = new List<Category>
            {
                new Category { strCategory = "Coffee" },
                new Category { strCategory = "Beer" },
                new Category { strCategory = "Wine" }
            }
        };

        return categories.CategoriesList.Select(x => x.strCategory).ToList();
    }
}
