using Scrum_Aufgabe;

public class Manager
{
    private List<UserStory> user_stories = new();

    public void AddUserStory()
    {
        Console.Write("Beschreibung: ");
        string beschreibung = Console.ReadLine();

        Console.Write("Bearbeiter: ");
        string bearbeiter = Console.ReadLine();

        Console.Write("Aufwand: ");
        int aufwand = int.Parse(Console.ReadLine());

        UserStory story =
            new UserStory(beschreibung, bearbeiter, aufwand);

        user_stories.Add(story);

        Console.WriteLine("User Story erfolgreich angelegt.");
    }

    public void ShowAllStories()
    {
        if (!user_stories.Any())
        {
            Console.WriteLine("Keine User Stories vorhanden.");
            return;
        }

        foreach (UserStory story in user_stories)
        {
            PrintStory(story);
        }
    }

    public void FilterStories()
    {
        Console.WriteLine("Status auswählen:");
        Console.WriteLine("1 = To Do");
        Console.WriteLine("2 = In Progress");
        Console.WriteLine("3 = Done");

        string input = Console.ReadLine();

        UserStoryStatus status;

        switch (input)
        {
            case "1":
                status = UserStoryStatus.ToDo;
                break;

            case "2":
                status = UserStoryStatus.InProgress;
                break;

            case "3":
                status = UserStoryStatus.Done;
                break;

            default:
                Console.WriteLine("Ungültige Eingabe.");
                return;
        }

        List<UserStory> filteredStories =
            user_stories.Where(s => s.Status == status).ToList();

        if (!filteredStories.Any())
        {
            Console.WriteLine("Keine passenden Stories gefunden.");
            return;
        }

        foreach (UserStory story in filteredStories)
        {
            PrintStory(story);
        }
    }

    public void ChangeStatusOfStory()
    {
        Console.Write("Beschreibung der gesuchten Story: ");
        string beschreibung = Console.ReadLine();

        UserStory story =
            user_stories.FirstOrDefault(
                s => s.Beschreibung.Equals(
                    beschreibung,
                    StringComparison.OrdinalIgnoreCase));

        if (story == null)
        {
            Console.WriteLine("Story nicht gefunden.");
            return;
        }

        Console.WriteLine("Neuen Status wählen:");
        Console.WriteLine("1 = To Do");
        Console.WriteLine("2 = In Progress");
        Console.WriteLine("3 = Done");

        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                story.Status = UserStoryStatus.ToDo;
                break;

            case "2":
                story.Status = UserStoryStatus.InProgress;
                break;

            case "3":
                story.Status = UserStoryStatus.Done;
                break;

            default:
                Console.WriteLine("Ungültige Eingabe.");
                return;
        }

        Console.WriteLine("Status erfolgreich geändert.");
    }

    public void ShowRemainingffort()
    {
        int remainingEffort = user_stories
            .Where(s => s.Status != UserStoryStatus.Done)
            .Sum(s => s.Aufwand);

        Console.WriteLine(
            $"Offener Gesamtaufwand: {remainingEffort}");
    }

    private void PrintStory(UserStory story)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Beschreibung: {story.Beschreibung}");
        Console.WriteLine($"Bearbeiter: {story.Bearbeiter}");
        Console.WriteLine($"Aufwand: {story.Aufwand}");
        Console.WriteLine($"Status: {story.Status}");
    }
}