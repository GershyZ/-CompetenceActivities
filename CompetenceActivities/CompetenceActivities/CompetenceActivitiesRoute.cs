using MentoringFramework.Pages;
using MentoringFramework.Models;
using MentoringFramework.Views;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace CompetenceActivities
{
    class CompetenceActivitiesRoute : Route
    {        
        public CompetenceActivitiesRoute() : base("Competence Activities", Color.Green, Color.Yellow)
        {
            var curr = new LevelPage("Goals");
            curr.addSection(new ResourcePDF("Goal Setting Guidelines"));
            curr.addSection(new BonusLevelPage("The Ten Year Race","Goal", new BonusFormBuilder()).asLevelContent());
            curr.addSection(new LevelPage("A Plan For My Goals").asLevelContent());
            curr.addSection(new LevelPage("My Long Term Goals Worksheet").asLevelContent());            
            this.StartLevel.addSection(curr.asLevelContent());
            curr = new LevelPage("Needs");
            curr.addSection(new ResourcePDF("Identifying Your Mentee's Needs"));
            curr.addSection(new Challenge("School:My Responsibility"));
            curr.addSection(new ResourcePDF("Time Management Tips"));
            curr.addSection(new BonusLevelPage("Identify Your Time Wasters", "Time Waster",new BonusFormBuilder()).asLevelContent());
            curr.addSection(new ResourcePDF("Using a Daily Planner"));
            this.StartLevel.addSection(curr.asLevelContent());
            curr = new LevelPage("Homework");
            curr.addSection(new ResourcePDF("Homework Time Table"));
            curr.addSection(new ResourcePDF("Helping With Homework"));
            LevelPage skills = new LevelPage("Developing Your Skills");
            curr.addSection(new ResourcePDF("7 Basic Homework Tips"));
            curr.addSection(skills.asLevelContent());
            curr = new LevelPage("Reading");
            curr.addSection(new ResourcePDF("5 Step Reading Process"));
            curr.addSection(new ResourcePDF("Foster Reading Enjoyment"));
            skills.addSection(curr.asLevelContent());
            curr = new LevelPage("Notetaking");
            curr.addSection(new ResourcePDF("How to Take Good Notes in Class"));
            curr.addSection(new ResourcePDF("The Cornell Method of Note-Taking"));
            curr.addSection(new Challenge("Using the Cornell Method of Note-Taking"));
            skills.addSection(curr.asLevelContent());
            curr = new LevelPage("Study Habits");
            curr.addSection(new Challenge("Assess Your Study Habits"));
            curr.addSection(new Challenge("Study Habits"));
            curr.addSection(new ResourcePDF("How to Prepare for Essay Tests"));
            curr.addSection(new ResourcePDF("How to Take True-False Tests"));
            curr.addSection(new ResourcePDF("How to Take Multiple Choice Tests"));

            skills.addSection(curr.asLevelContent());
            //stopped at page 22            
            curr = new LevelPage("Career Exploration");
            //curr.addSection(null);
            this.StartLevel.addSection(curr.asLevelContent());
            curr = new LevelPage("Graduation Requirements");
            //curr.addSection(null);
            this.StartLevel.addSection(curr.asLevelContent());
            curr = new LevelPage("Applying to College");
            //curr.addSection(null);
            this.StartLevel.addSection(curr.asLevelContent());
            _startRoute();
        }
    }
}
