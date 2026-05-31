
namespace Scrum_Aufgabe.Tests;

[TestFixture]
public class ScrumBoardTests
{
    private Manager _manager = null!;

    [SetUp]
    public void SetUp()
    {
        _manager = new Manager();
    }

    [Test]
    public void AddUserStory_SpeichertStoryKorrekt()
    {
        _manager.AddUserStory("Login erstellen", "Max Müller", 5);

        var story = _manager.GetAllStories().First();
        Assert.That(story.Beschreibung, Is.EqualTo("Login erstellen"));
        Assert.That(story.Bearbeiter, Is.EqualTo("Max Müller"));
        Assert.That(story.Aufwand, Is.EqualTo(5));
        Assert.That(story.Status, Is.EqualTo(UserStoryStatus.ToDo));
    }

    [Test]
    public void GetAllStories_GibtAlleStoriesZurueck()
    {
        _manager.AddUserStory("Story A", "Dev 1", 3);
        _manager.AddUserStory("Story B", "Dev 2", 5);

        Assert.That(_manager.GetAllStories().Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetStoriesByStatus_GibtNurPassendeStoriesZurueck()
    {
        _manager.AddUserStory("Story ToDo", "Dev A", 3);
        _manager.AddUserStory("Story Done", "Dev B", 5);
        _manager.ChangeStatus("Story Done", UserStoryStatus.Done);

        var result = _manager.GetStoriesByStatus(UserStoryStatus.ToDo).ToList();

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Beschreibung, Is.EqualTo("Story ToDo"));
    }

    [Test]
    public void ChangeStatus_AendertStatusKorrekt()
    {
        _manager.AddUserStory("Feature X", "Dev A", 5);

        bool result = _manager.ChangeStatus("Feature X", UserStoryStatus.InProgress);

        Assert.That(result, Is.True);
        Assert.That(_manager.GetAllStories().First().Status,
            Is.EqualTo(UserStoryStatus.InProgress));
    }

    [Test]
    public void GetRemainingEffort_ZaehltNurNichtAbgeschlosseneStories()
    {
        _manager.AddUserStory("Offen", "Dev A", 3);
        _manager.AddUserStory("Laufend", "Dev B", 5);
        _manager.AddUserStory("Fertig", "Dev C", 10);
        _manager.ChangeStatus("Laufend", UserStoryStatus.InProgress);
        _manager.ChangeStatus("Fertig", UserStoryStatus.Done);

        Assert.That(_manager.GetRemainingEffort(), Is.EqualTo(8)); // 3 + 5
    }
}