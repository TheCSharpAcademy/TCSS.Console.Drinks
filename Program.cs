using Spectre.Console;
using System.Diagnostics;
using TCSS.Console.Drinks;

Console.WriteLine("Starting time-consuming operations...");

Stopwatch stopwatch = Stopwatch.StartNew();

Task task1 = FetchUserDataAsync();
Task task2 = FetchProductDataAsync();
Task task3 = FetchInvoiceDataAsync();

await Task.WhenAll(task1, task2, task3);

stopwatch.Stop();

Console.WriteLine("All time-consuming operations have completed.");
Console.WriteLine($"Total time elapsed: {stopwatch.Elapsed.TotalSeconds} seconds");
Console.WriteLine("The console application remains responsive.");

async Task FetchUserDataAsync()
{
    await Task.Delay(5000); 
}

async Task FetchProductDataAsync()
{
    await Task.Delay(5000); 
}

async Task FetchInvoiceDataAsync()
{
    await Task.Delay(5000);
}

while (true)
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Drinks Menu"));
    UserInput userInput = new();
    userInput.GetCategoriesInput();
}