using System;
using System.Collections.Generic;
using System.Text;
using MentoringFramework.Pages;
using MentoringFramework.Views;
namespace MentoringFramework.Models
{
    public interface BonusGoalForm
    {
        Challenge onComplete();
        Xamarin.Forms.Page asPage();
        void addButtonFunctionality(LevelPage parent);
    }
}
