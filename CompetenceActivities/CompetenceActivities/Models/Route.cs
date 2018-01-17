using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MentoringFramework.Pages;
namespace MentoringFramework.Models
{
    public class Route : Application

    {
        public String RouteName;
        public LevelPage StartLevel;        
        public static Xamarin.Forms.Color PrimaryColor;
        public static Xamarin.Forms.Color SecondaryColor;
        private static Stack<LevelPage> _history_stack;
        public Route(String name, Color pcolor, Color scolor)
        {
            RouteName = name;            
            PrimaryColor = pcolor;
            SecondaryColor = scolor;
            _history_stack = new Stack<LevelPage>();
            StartLevel = new LevelPage(RouteName);
        }

        public static void switchPage(LevelPage page)
        {
            if (_history_stack.Contains(page))
            {
                goBack(new BearTrack(page));
            }
            else
            {
                _history_stack.Push(page);
                page.populateBeartracks(_history_stack);
                var nav = new NavigationPage(page);
                Current.MainPage = nav;
            }
        }

        public static void goBack(BearTrack track)
        {
            bool found = false;
            if (track == null || _history_stack.Count == 0)
            {
                found = true;
            }
            LevelPage curr = null;
            while (_history_stack.Count > 0 && _history_stack.Peek() != null && !found)
            {
                curr = _history_stack.Pop();
                if (curr.Equals(track.getPage()))
                {
                    found = true;
                }
            }
            if (found)
            {
                var nav = new NavigationPage(track.getPage());
                _history_stack.Push(track.getPage());
                Application.Current.MainPage = nav;
            }
        }

        public static Stack<LevelPage> getHistory()
        {
            return _history_stack;
        }

        protected void _startRoute()
        {
            Current.MainPage = new NavigationPage(StartLevel);
        }
    }
}    