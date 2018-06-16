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
		public MainPage()
		{
			InitializeComponent();
		    BindingContext = new Weather();
		}

	    public async void SearchByCityButtonClicked(object sender, EventArgs e)
	    {
	        string cityKey = "";
            cityKey = await API.GetCityKey(EntryCityName.Text);
            Weather weather = await API.GetWeatherForCity(cityKey);
            BindingContext = weather;
        }

	    public async void AddNewCityButtonClicked(object sender, EventArgs e)
	    {
	        string cityKey = await API.GetCityKey(AddNewCityEntry.Text);
            Application.Current.Properties.Add(cityKey, AddNewCityEntry.Text);
	    }
	}
}
