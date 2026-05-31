using System;
using System.Collections.Generic;
using System.Text;

namespace Scrum_Aufgabe
{
    public class Verwaltung
    {
        public List<User_Story> user_stories;
        public void AddUserStory(string _beschreibung, string _bearbeiter, int _aufwand)
        {
            User_Story new_story = new User_Story(_beschreibung, _bearbeiter, _aufwand);
            user_stories.Add(new_story);
        }

        public List<User_Story> ShowAllStories()
        {
            return user_stories;
        }

        public User_Story FilterByStatus(UserStoryStatus _status)
        {
            return user_stories.Where(s => s.Status == _status);
        }

        public void ChangeStatusOfStory(UserStoryStatus _status, string _beschreibung)
        {
            User_Story storyToBeChanged = user_stories.Where(s => s.Beschreibung.Contains(_beschreibung)).FirstOrDefault();
            storyToBeChanged.status = _status;
        }

        public int ShowRemainingExpenditure()
        {
            int count = 0;

            foreach(User_Story _story in user_stories)
            {
                if(_story.Status != UserStoryStatus.Done)
                {
                    count = count + _story.Aufwand;
                }
            }

            return count;
        }

        public void CloseApp()
        {
            return;
        }
    }
}
