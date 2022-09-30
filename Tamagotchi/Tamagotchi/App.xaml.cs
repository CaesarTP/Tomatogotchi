using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            System.Diagnostics.Debug.WriteLine("Hello World, I'm an app and I just started.");
        }

        protected override void OnSleep()
        {
            //var sleepTime = DateTime.UtcNow;
            //Preferences.Set("SleepTime", sleepTime);
        }

        protected override void OnResume()
        {
            //var sleepTime = Preferences.Get("SleepTime", DateTime.UtcNow);
            //var timePassed = DateTime.UtcNow - sleepTime;

            //timePassed.TotalSeconds
        }
    }
}
