using System;

using Xamarin.Forms;
using System.Collections.Generic;
using MentoringFramework.Models;
using MentoringFramework.Views;
namespace MentoringFramework.Pages
{
    public partial class BonusFormBuilder : ContentPage, BonusGoalForm
    {
        Entry e_headline;
        Dictionary<String, View> _fields;
        public BonusFormBuilder()
        {
            InitializeComponent();
            _fields = new Dictionary<string, View>();
        }
        public void addDateEntry(string label)
        {
            DatePicker dp = new DatePicker();
            dp.HorizontalOptions = LayoutOptions.FillAndExpand;
            _addInputField(label, dp);
        }

        public void addDropdownEntry(string label, String[] choices)
        {
            Picker dropdown = new Picker();
            for (int i = 0; i < choices.Length; i++)
            {
                dropdown.Items.Add(choices[i]);
            }
            _addInputField(label, dropdown);
        }

        public void addTextEntry(String label, bool isheadline = false)
        {
            Entry currentry = new Entry();
            _addInputField(label, currentry);
            if (isheadline || e_headline == null)
            {
                e_headline = currentry;
            }
        }
        private void _addInputField(String label, View input)
        {
            StackLayout currfield = new StackLayout();

            input.HorizontalOptions = LayoutOptions.FillAndExpand;
            currfield.Orientation = StackOrientation.Horizontal;
            currfield.Children.Add(new Label { Text = label });
            currfield.Children.Add(input);
            _fields.Add(label, input);
            sl_fields.Children.Add(currfield);
            sl_header.BackgroundColor = Route.PrimaryColor;
            sl_fields.BackgroundColor = Route.PrimaryColor;
        }

        public String getFieldValue(String label)
        {
            View value;
            String fieldtext = "";
            _fields.TryGetValue(label, out value);
            if (value != null)
            {
                if (value.GetType().Equals(typeof(Entry)))
                {
                    fieldtext = ((Entry)value).Text;
                }
                else if (value.GetType().Equals(typeof(Picker)))
                {
                    Picker p = (Picker)value;
                    try
                    {
                        fieldtext = p.Items[p.SelectedIndex];
                    }
                    catch (ArgumentOutOfRangeException e)
                    {                        
                        fieldtext = "1";
                    }
                }
                else if (value.GetType().Equals(typeof(DatePicker)))
                {
                    fieldtext = String.Format("dd MMMM yyyy", ((DatePicker)value).ToString());
                }
            }
            return fieldtext;
        }

        public void disableField(String label)
        {
            View value;
            _fields.TryGetValue(label, out value);
            if (value != null)
            {
                value.IsEnabled = false;
            }
        }

        public void enableField(String label)
        {
            View value;
            _fields.TryGetValue(label, out value);
            if (value != null)
            {
                value.IsEnabled = true;
            }
        }
        public Page asPage()
        {
            return this;
        }

        public virtual Challenge onComplete()
        {
            return new Challenge(e_headline.Text, -1);
        }

        public void addButtonFunctionality(LevelPage parent)
        {
            b_cancel.Clicked += delegate
            {
                parent.Navigation.PopModalAsync();
            };
            b_submit.Clicked += delegate
            {
                parent.addSection(onComplete());
                parent.Navigation.PopModalAsync();
            };
        }
    }
}