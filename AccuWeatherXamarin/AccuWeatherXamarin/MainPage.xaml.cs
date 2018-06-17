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
	        if(this.CheckExistingCity())
            { return;}
	        string cityKey = await API.GetCityKey(AddNewCityEntry.Text);
	        CityRepository.AddCityToDb(new City { Code = cityKey, Name = AddNewCityEntry.Text });
	        ChooseCityPicker.Items.Add(AddNewCityEntry.Text);
	    }

	    public async void DeleteCityButtonClicked(object sender, EventArgs e)
	    {
	        string cityName = ChooseCityPicker.SelectedItem as string;
            ChooseCityPicker.Items.Remove(ChooseCityPicker.SelectedItem as string);
	        try
	        {
                string cityKey = await API.GetCityKey(cityName);

                CityRepository.DeleteCityFromDb(new City { Code = cityKey, Name = ChooseCityPicker.SelectedItem as string });
            }
	        catch (Exception exception)
	        {
	            EntryCityName.Text = exception.Message;
	        }
            
	    }

	    public bool CheckExistingCity()
	    {
	        foreach (var currentProperty in Application.Current.Properties)
	        {
	            if (currentProperty.Value as string == AddNewCityEntry.Text)
	            {
	                EntryCityName.Text = "This city already exist";
	                return true;
	            }
	        }

	        return false;
	    }
	}
}
