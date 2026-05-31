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
        case "1":
            manager.AddUserStory();
            break;

        case "2":
            manager.ShowAllStories();
            break;

        case "3":
            manager.FilterStories();
            break;

        case "4":
            manager.ChangeStatusOfStory();
            break;

        case "5":
            manager.ShowRemainingffort();
            break;

        case "6":
            running = false;
            break;

        default:
            Console.WriteLine("Ungültige Eingabe.");
            break;
    }

    if (running)
    {
        Console.WriteLine();
        Console.WriteLine("Weiter mit Enter...");
        Console.ReadLine();
    }
}