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
		    BindingContext = mainPageViewModel;

		}

	    public async void SearchByCityButtonClicked(object sender, EventArgs e)
	    {
	        string cityKey = "";
            cityKey = await API.GetCityKey(ChooseCityPicker.SelectedItem.ToString());
            Weather weather = await API.GetWeatherForCity(cityKey);
	        mainPageViewModel.Weather = weather;
            BindingContext = mainPageViewModel;
        }

	    public async void AddNewCityButtonClicked(object sender, EventArgs e)
	    {
	        AddNewCity();
	        BindingContext = mainPageViewModel;
	    }

	    private async void AddNewCity()
	    {
	        string cityKey = await API.GetCityKey(AddNewCityEntry.Text);
	        CityRepository.AddCityToDb(new City { Code = cityKey, Name = AddNewCityEntry.Text });
	        mainPageViewModel.Cities = CityRepository.GetCityList();
        }
	}
}
