using Spectre.Console;
using TCSS.Console.Drinks;

while (true)
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Drinks Menu"));
    UserInput userInput = new();
    await userInput.GetCategoriesInput();
}