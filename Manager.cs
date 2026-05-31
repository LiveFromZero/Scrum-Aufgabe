using System;
using System.Collections.Generic;
using System.Text;

namespace Scrum_Aufgabe
{
    public class Manager
    {
        public List<UserStory> user_stories = new List<UserStory>();
        public void AddUserStory(string _beschreibung, string _bearbeiter, int _aufwand)
        {
            UserStory new_story = new UserStory(_beschreibung, _bearbeiter, _aufwand);
            user_stories.Add(new_story);
        }

        public List<UserStory> ShowAllStories()
        {
            return user_stories;
        }

        public List<UserStory> FilterByStatus(UserStoryStatus _status)
        {
            return user_stories.Where(s => s.Status == _status).ToList();
        }

        public void ChangeStatusOfStory(UserStoryStatus _status, string _beschreibung)
        {
            UserStory storyToBeChanged = user_stories.Where(s => s.Beschreibung.Contains(_beschreibung)).FirstOrDefault();
            storyToBeChanged.Status = _status;
        }

        public int ShowRemainingExpenditure()
        {
            int count = 0;

            foreach(UserStory _story in user_stories)
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
