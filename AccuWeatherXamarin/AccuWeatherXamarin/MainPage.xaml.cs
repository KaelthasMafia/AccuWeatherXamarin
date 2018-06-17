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
            foreach (var currentProperty in Application.Current.Properties) ChooseCityPicker.Items.Add(currentProperty.Value as string);
        }

        public async void SearchByCityButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var cityKey = await API.GetCityKey(ChooseCityPicker.SelectedItem.ToString());
                var weather = await API.GetWeatherForCity(cityKey);
                BindingContext = weather;
            }
            catch (ArgumentOutOfRangeException)
            {
                EntryCityName.Text = "Please, choose city from picker!";
            }
        }

        public async void AddNewCityButtonClicked(object sender, EventArgs e)
        {
            if (CheckExistingCity(AddNewCityEntry.Text))
            {
                EntryCityName.Text = "This city already exist";
                return;
            }

            try
            {
                var cityKey = await API.GetCityKey(AddNewCityEntry.Text);
                CityRepository.AddCityToDb(new City {Code = cityKey, Name = AddNewCityEntry.Text});
                ChooseCityPicker.Items.Add(AddNewCityEntry.Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                EntryCityName.Text = "Invalid city name!";
            }
        }

        public async void DeleteCityButtonClicked(object sender, EventArgs e)
        {
            var cityName = ChooseCityPicker.SelectedItem as string;
            ChooseCityPicker.Items.Remove(ChooseCityPicker.SelectedItem as string);
            var cityKey = await API.GetCityKey(cityName);
            CityRepository.DeleteCityFromDb(new City {Code = cityKey, Name = ChooseCityPicker.SelectedItem as string});
        }

        public static bool CheckExistingCity(string cityName)
        {
            //foreach (var currentProperty in Application.Current.Properties)
            //    if (currentProperty.Value as string == cityName) return true;

            return false;
        }
    }
}
