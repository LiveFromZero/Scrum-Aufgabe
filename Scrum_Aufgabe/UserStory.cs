using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Scrum_Aufgabe
{
    public class UserStory
    {
        public string Beschreibung { get; set;  }
        public string Bearbeiter { get; set; }
        public int Aufwand { get; set; }
        public UserStoryStatus Status {  get; set; }

        public UserStory(string beschreibung, string bearbeiter, int aufwand)
        {
            Beschreibung = beschreibung;
            Bearbeiter = bearbeiter;
            Aufwand = aufwand;
            Status = UserStoryStatus.ToDo;
        }
    }

    public enum UserStoryStatus
        {
            [Description("To Do")]
            ToDo,
            [Description("In Progress")]
            InProgress,
            Done
        }
}
