using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Scrum_Aufgabe
{
    public class User_Story
    {
        private string Beschreibung { get; set;  }
        private string Bearbeiter { get; set; }
        private int Aufwand { get; set; }
        private UserStoryStatus Status {  get; set; }

        public User_Story(string beschreibung, string bearbeiter, int aufwand)
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
