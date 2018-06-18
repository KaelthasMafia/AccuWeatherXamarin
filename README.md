# AccuWeatherXamarin

To launch AccuWeatherXamarin.UWP application you must have Windows 10 Fall Creators Update (10.0; Build 16299) or higher

To test this application you need download Windows Application Driver by the following link http://download.microsoft.com/download/6/8/7/687DEE85-E907-4A95-8035-8BC969B9EA95/WindowsApplicationDriver.msi

Then you need run this application, which will be in C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe and run solution in debug mode, which install the application to your computer. 

If application doesn't works - you need to change API key in sourse code (MainForm.xaml.cs), because AccuWeather free API has a limited number of requests.
