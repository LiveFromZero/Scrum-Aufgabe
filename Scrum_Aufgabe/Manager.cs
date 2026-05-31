using Scrum_Aufgabe;

public class Manager
{
    private List<UserStory> _stories = new();

    public void AddUserStory(string beschreibung, string bearbeiter, int aufwand)
    {
        if (DescriptionAlreadyExists(beschreibung))
            throw new InvalidOperationException(
                "Eine User Story mit dieser Beschreibung existiert bereits.");

        _stories.Add(new UserStory(beschreibung, bearbeiter, aufwand));
    }

    public IEnumerable<UserStory> GetAllStories() => _stories;

    public IEnumerable<UserStory> GetStoriesByStatus(UserStoryStatus status)
        => _stories.Where(s => s.Status == status);

    public bool ChangeStatus(string beschreibung, UserStoryStatus neuerStatus)
    {
        var story = _stories.FirstOrDefault(
            s => s.Beschreibung.Equals(beschreibung, StringComparison.OrdinalIgnoreCase));

        if (story == null) return false;

        story.Status = neuerStatus;
        return true;
    }

    public int GetRemainingEffort()
        => _stories
            .Where(s => s.Status != UserStoryStatus.Done)
            .Sum(s => s.Aufwand);

    public void AddUserStoryInteractive()
    {
        string beschreibung;
        do
        {
            Console.Write("Beschreibung: ");
            beschreibung = Console.ReadLine();

            if (DescriptionAlreadyExists(beschreibung))
                Console.WriteLine("Eine User Story mit dieser Beschreibung existiert bereits. Bitte eine andere eingeben.");

        } while (DescriptionAlreadyExists(beschreibung));

        Console.Write("Bearbeiter: ");
        string bearbeiter = Console.ReadLine();

        Console.Write("Aufwand: ");
        int aufwand;
        while (!int.TryParse(Console.ReadLine(), out aufwand))
        {
            Console.WriteLine("Ungültige Eingabe. Bitte eine ganze Zahl eingeben:");
            Console.Write("Aufwand: ");
        }

        AddUserStory(beschreibung, bearbeiter, aufwand);
        Console.WriteLine("User Story erfolgreich angelegt.");
    }

    public void ShowAllStoriesInteractive()
    {
        var stories = GetAllStories().ToList();

        if (!stories.Any())
        {
            Console.WriteLine("Keine User Stories vorhanden.");
            return;
        }

        foreach (var story in stories)
            PrintStory(story);
    }

    public void FilterStoriesInteractive()
    {
        Console.WriteLine("Status auswählen:");
        Console.WriteLine("1 = To Do");
        Console.WriteLine("2 = In Progress");
        Console.WriteLine("3 = Done");

        string input = Console.ReadLine();

        UserStoryStatus status;
        switch (input)
        {
            case "1": status = UserStoryStatus.ToDo; break;
            case "2": status = UserStoryStatus.InProgress; break;
            case "3": status = UserStoryStatus.Done; break;
            default:
                Console.WriteLine("Ungültige Eingabe.");
                return;
        }

        var filtered = GetStoriesByStatus(status).ToList();

        if (!filtered.Any())
        {
            Console.WriteLine("Keine passenden Stories gefunden.");
            return;
        }

        foreach (var story in filtered)
            PrintStory(story);
    }

    public void ChangeStatusInteractive()
    {
        Console.Write("Beschreibung der gesuchten Story: ");
        string beschreibung = Console.ReadLine();

        Console.WriteLine("Neuen Status wählen:");
        Console.WriteLine("1 = To Do");
        Console.WriteLine("2 = In Progress");
        Console.WriteLine("3 = Done");

        string input = Console.ReadLine();

        UserStoryStatus neuerStatus;
        switch (input)
        {
            case "1": neuerStatus = UserStoryStatus.ToDo; break;
            case "2": neuerStatus = UserStoryStatus.InProgress; break;
            case "3": neuerStatus = UserStoryStatus.Done; break;
            default:
                Console.WriteLine("Ungültige Eingabe.");
                return;
        }

        bool gefunden = ChangeStatus(beschreibung, neuerStatus);
        Console.WriteLine(gefunden ? "Status erfolgreich geändert." : "Story nicht gefunden.");
    }

    public void ShowRemainingEffortInteractive()
    {
        Console.WriteLine($"Offener Gesamtaufwand: {GetRemainingEffort()}");
    }

    private bool DescriptionAlreadyExists(string beschreibung)
        => _stories.Any(s => s.Beschreibung.Equals(
            beschreibung, StringComparison.OrdinalIgnoreCase));

    private void PrintStory(UserStory story)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Beschreibung: {story.Beschreibung}");
        Console.WriteLine($"Bearbeiter:   {story.Bearbeiter}");
        Console.WriteLine($"Aufwand:      {story.Aufwand}");
        Console.WriteLine($"Status:       {story.Status}");
    }
}