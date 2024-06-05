using Spectre.Console;
using TCSS.Console.Drinks;

namespace TCss.Console.Drinks.Helpers;

public class TableVisualisation
{
    internal static Table ShowTable(DrinkDetail tableData)
    {
        var table = new Table();
        var props = tableData.GetType().GetProperties().ToList();

        table.AddColumn("");
        table.AddColumn("");

        foreach (var prop in props)
        {
            var value = prop.GetValue(tableData)?.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                table.AddRow(prop.Name, value);
            }
        }

        return table;
    }
}