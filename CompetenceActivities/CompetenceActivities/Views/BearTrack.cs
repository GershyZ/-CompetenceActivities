using System;
using Xamarin.Forms;

using MentoringFramework.Models;
using MentoringFramework.Pages;
namespace MentoringFramework
{
	public class BearTrack : Button
	{
		LevelPage _page;
		public BearTrack(LevelPage page) : base()
		{
			_page = page;
			Text = "UKN";
            BackgroundColor = Route.PrimaryColor;
            TextColor = Route.SecondaryColor;
			if (page.Title != null)
			{
				Text = page.Title.Substring(0, (page.Title.Length > 3 ? 4 : page.Title.Length));
			}
			Clicked += delegate
			{
	                                                                                                          			Route.goBack(this);
			};
			this.VerticalOptions = LayoutOptions.Start;
		}
		public LevelPage getPage()
		{
			return _page;
		}

	}
}
