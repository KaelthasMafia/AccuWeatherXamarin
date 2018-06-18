# AccuWeatherXamarin

To test this application you have to download Windows Application Driver by the following link http://download.microsoft.com/download/6/8/7/687DEE85-E907-4A95-8035-8BC969B9EA95/WindowsApplicationDriver.msi

Then you have to run this application, which you can find in C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe, and run solution in debug mode, which would install the application on your computer. 

In case the application doesn't work, you need to change the API key in sourse code (MainForm.xaml.cs), because AccuWeather free API allows limited number of requests.
