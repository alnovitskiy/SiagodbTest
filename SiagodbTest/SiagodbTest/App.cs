using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SiagodbTest.DbModels;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SiagodbTest
{
	public class App : Application
	{
		public App ()
		{
		    var btnCreate = new Button() {Text = "Create db and add data"};
            btnCreate.Clicked += OnButtonClicked;

            var btnUpdate = new Button() { Text = "Update data"};
            btnUpdate.Clicked += OnButtonUpdateClicked;

            var btnTest = new Button() { Text = "Test data" };
            btnTest.Clicked += OnButtonTestClicked;

            // The root page of your application
            MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children = { btnCreate, btnUpdate, btnTest }
				}
			};
		}

        private void OnButtonClicked(object sender, EventArgs e)
	    {
	        try
	        {
                var database = SiaqodbFactory.GetInstance();
                database.DropType<SimpleModel>();
                var model = new SimpleModel();
                model.Items = new List<SimpleItem>();
                model.Items.Add(new SimpleItem() { Property1 = "valu1", Property2 = "value2" });
                database.StoreObject(model);
            }
	        catch (Exception ex)
	        {
                MainPage.DisplayAlert("Error", ex.Message, "OK");
	        }
	    }

        private void OnButtonUpdateClicked(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var database = SiaqodbFactory.GetInstance();
                var model = (from SimpleModel m in database select m).First();
                var item = model.Items.First();
                item.Property1 = "new value1";
                item.Property2 = "new value2";
                database.StoreObject(model);
            });

        }

        private void OnButtonTestClicked(object sender, EventArgs e)
        {
            var database = SiaqodbFactory.GetInstance();
            var model = (from SimpleModel m in database select m).First();
            var item = model.Items.First();
                        
            if(item.Property1 != "new value1" || item.Property2 != "new value2")
            {
                MainPage.DisplayAlert("Error", "Data wasn't updated correctly", "OK");
            }
        }
    }
}
