using System;
using System.Collections.Generic;
using System.Text;
using MentoringFramework.Models;

using Xamarin.Forms;
namespace  MentoringFramework.Pages
{
    public class BonusLevelPage : LevelPage
    {
        Button b_add;
        BonusGoalForm _form;

        public BonusLevelPage(String title, String objectname, BonusGoalForm form) : base(title)
        {
            _form = form;
            b_add = new Button();
            b_add.Text = String.Format("Add new {0}", objectname);
            b_add.Clicked += delegate
            {
                _showForm();
            };
            _addToHeader(b_add);
        }

        public BonusLevelPage(String title, Type formtype) : base(title)
        {
            b_add = new Button();
            b_add.Text = String.Format("Add new {0}", title);
            b_add.Clicked += delegate
            {
                try
                {
                    _form = (BonusGoalForm)Activator.CreateInstance(formtype);
                    _showForm();
                }
                catch (InvalidCastException e)
                {
                    //Debug.WriteLine(e.Message);
                }

            };
            _addToHeader(b_add);
        }

        protected void _showForm()
        {
            _form.addButtonFunctionality(this);
            this.Navigation.PushModalAsync(_form.asPage(), true);

        }

        protected void _setButtonText(String text)
        {
            b_add.Text = text;
        }
    }
}