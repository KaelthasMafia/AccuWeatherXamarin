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

            try
	        {
	            cityKey = await API.GetCityKey("Kharkiv");
	        }
	        catch (Exception ex)
	        {
	            EntryCityName.Text = ex.Message;
	        }

	        //Weather weather = await API.GetWeatherForCity(cityKey);
	        //BindingContext = weather;
	    }
	}
}
