using Scrum_Aufgabe;

Manager manager = new Manager();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine(ConsoleTexts.WelcomeText);

    string input = Console.ReadLine();

    switch (input)
    {
        case "1": manager.AddUserStoryInteractive(); break;
        case "2": manager.ShowAllStoriesInteractive(); break;
        case "3": manager.FilterStoriesInteractive(); break;
        case "4": manager.ChangeStatusInteractive(); break;
        case "5": manager.ShowRemainingEffortInteractive(); break;
        case "6": running = false; break;
        default: Console.WriteLine("Ungültige Eingabe."); break;
    }

    if (running)
    {
        Console.WriteLine();
        Console.WriteLine("Weiter mit Enter...");
        Console.ReadLine();
    }
}