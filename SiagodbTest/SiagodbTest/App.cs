using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SiagodbTest.DbModels;
using Xamarin.Forms;

namespace SiagodbTest
{
	public class App : Application
	{
		public App ()
		{
		    var btn = new Button() {Text = "Create Siagodb instance"};
		    btn.Clicked += OnButtonClicked;

            var btnStingTest = new Button() { Text = "Test string field" };
            btnStingTest.Clicked += OnButtonStingTestClicked;

			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children = { btn, btnStingTest }
				}
			};
		}

	    private void OnButtonStingTestClicked(object sender, EventArgs e)
	    {
            var str = "Very long string 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 ";
            var database = SiaqodbFactory.GetInstance();
            database.DropType<SimpleModel>();
            database.StoreObject(new SimpleModel() { StringField = str }/*, this.transaction*/);
            MainPage.DisplayAlert("", "We saved an object with property StringField = "+str, "OK").ContinueWith((task) =>
	        {
                var model = database.Cast<SimpleModel>().ToList().First();
                Device.BeginInvokeOnMainThread(() => MainPage.DisplayAlert("", "We got this object from the db and property StringField = " + model.StringField, "OK"));
	        });
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
