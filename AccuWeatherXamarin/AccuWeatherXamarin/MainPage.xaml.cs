using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccuWeatherXamarin.Models;
using Xamarin.Forms;

namespace AccuWeatherXamarin
{
	public partial class MainPage : ContentPage
	{
	    private readonly MainPageViewModel mainPageViewModel;
		public MainPage()
		{
			InitializeComponent();
		    mainPageViewModel = new MainPageViewModel {Cities = CityRepository.GetCityList()};
            //BindingContext = mainPageViewModel;
            foreach (var currentProperty in Application.Current.Properties)
            {
                ChooseCityPicker.Items.Add(currentProperty.Value as string);
            }
		}

	    public async void SearchByCityButtonClicked(object sender, EventArgs e)
	    {
	        string cityKey = "";
            cityKey = await API.GetCityKey(ChooseCityPicker.SelectedItem.ToString());
            //cityKey = await API.GetCityKey(EntryCityName.Text);
            Weather weather = await API.GetWeatherForCity(cityKey);
            BindingContext = weather;
        }

	    public async void AddNewCityButtonClicked(object sender, EventArgs e)
	    {
	        foreach (var currentProperty in Application.Current.Properties)
	        {
	            if (currentProperty.Value as string == AddNewCityEntry.Text)
	            {
	                EntryCityName.Text = "This city already exist";
                    return;
	            }
	        }
	        string cityKey = await API.GetCityKey(AddNewCityEntry.Text);
	        CityRepository.AddCityToDb(new City { Code = cityKey, Name = AddNewCityEntry.Text });
	        ChooseCityPicker.Items.Add(AddNewCityEntry.Text);
            //BindingContext = mainPageViewModel;
	    }

	    public void DeleteCityButtonClicked(object sender, EventArgs e)
	    {
	        ChooseCityPicker.Items.Remove(ChooseCityPicker.SelectedItem as string);
	    }
	}
}
