﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccuWeatherXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AccuWeatherXamarin
{
    public partial class MainPage : ContentPage
    {
        private readonly API api;

        public MainPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.Count == 0)
            {
                CityRepository.AddCityToDb(new City {Code = "323903", Name = "Kharkiv"});
            }

            foreach (var currentProperty in Application.Current.Properties)
                ChooseCityPicker.Items.Add(currentProperty.Value as string);
            if (ChooseCityPicker.Items.Count > 0)
            {
                ChooseCityPicker.SelectedIndex = 0;
            }

            api = new API("H8rzfG7CG0NfbUquNay1wZwlFnVizMF0");
        }

        public async void SearchByCityButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var cityKey = await api.GetCityKey(ChooseCityPicker.SelectedItem.ToString());
                var weather = await api.GetWeatherForCity(cityKey);
                BindingContext = weather;
                NotificationEntry.Text = "";
            }
            catch (Exception)
            {
                NotificationEntry.Text = "Please, choose city from picker!";
            }
        }

        public async void AddNewCityButtonClicked(object sender, EventArgs e)
        {
            if (CheckExistingCity(AddNewCityEntry.Text))
            {
                NotificationEntry.Text = "This city already exist";
                return;
            }

            try
            {
                var cityKey = await api.GetCityKey(AddNewCityEntry.Text);
                CityRepository.AddCityToDb(new City {Code = cityKey, Name = AddNewCityEntry.Text});
                ChooseCityPicker.Items.Add(AddNewCityEntry.Text);
                NotificationEntry.Text = "Successfully saved!";
                ChooseCityPicker.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                NotificationEntry.Text = "Invalid city name!";
            }
        }

        public async void DeleteCityButtonClicked(object sender, EventArgs e)
        {
            var cityName = ChooseCityPicker.SelectedItem as string;
            ChooseCityPicker.Items.Remove(ChooseCityPicker.SelectedItem as string);
            var cityKey = await api.GetCityKey(cityName);
            CityRepository.DeleteCityFromDb(new City {Code = cityKey, Name = ChooseCityPicker.SelectedItem as string});
            NotificationEntry.Text = "Successfully deleted!";
        }

        public static bool CheckExistingCity(string cityName)
        {
            foreach (var currentProperty in Application.Current.Properties)
                if (currentProperty.Value as string == cityName)
                    return true;
            return false;
        }
    }
}
