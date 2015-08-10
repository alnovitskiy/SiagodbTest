using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SiagodbTest
{
	public class App : Application
	{
		public App ()
		{
		    var btn = new Button() {Text = "Create Siagodb instance"};
		    btn.Clicked += OnButtonClicked;
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
					Children = {btn}
				}
			};
		}

	    private void OnButtonClicked(object sender, EventArgs e)
	    {
	        try
	        {
                var database = SiaqodbFactory.GetInstance();
                if (database != null) MainPage.DisplayAlert("", "The db instance was created successfully", "OK");
	        }
	        catch (Exception ex)
	        {
                MainPage.DisplayAlert("Error", ex.Message, "OK");
	        }
	    }
	}
}
