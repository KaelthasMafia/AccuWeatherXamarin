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
            ChooseCityPicker.Items.Add("Kharkiv");
            ChooseCityPicker.Items.Add("Kyiv");
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
	        string cityKey = await API.GetCityKey(AddNewCityEntry.Text);
	        CityRepository.AddCityToDb(new City { Code = cityKey, Name = AddNewCityEntry.Text });
	        mainPageViewModel.Cities.Add(AddNewCityEntry.Text);
            //BindingContext = mainPageViewModel;
	    }
	}
}
