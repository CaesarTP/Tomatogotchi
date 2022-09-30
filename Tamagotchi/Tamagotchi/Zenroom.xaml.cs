using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Zenroom : ContentPage
    {
        public float Hunger { get; set; } = 1;
        public float Thirst { get; set; } = 1;
        public float Sleepy { get; set; } = 1;
        public float Bored { get; set; } = 1;
        public float Overstimulated { get; set; } = 1;

        public Timer hungerTimer;
        public Timer thirstTimer;
        public Timer sleepyTimer;
        public Timer boredTimer;
        public Timer overstimulatedTimer;

        public Zenroom()
        {
            BindingContext = this;

            InitializeComponent();

            hungerTimer = new Timer();
            hungerTimer.Interval = 1000.0;
            hungerTimer.AutoReset = true;
            hungerTimer.Elapsed += Timer_Elapsed;
            hungerTimer.Start();

            thirstTimer = new Timer();
            thirstTimer.Interval = 1000.0;
            thirstTimer.AutoReset = true;
            thirstTimer.Elapsed += Timer_Elapsed;
            thirstTimer.Start();

            sleepyTimer = new Timer();
            sleepyTimer.Interval = 1000.0;
            sleepyTimer.AutoReset = true;
            sleepyTimer.Elapsed += Timer_Elapsed;
            sleepyTimer.Start();

            boredTimer = new Timer();
            boredTimer.Interval = 1000.0;
            boredTimer.AutoReset = true;
            boredTimer.Elapsed += Timer_Elapsed;
            boredTimer.Start();

            overstimulatedTimer = new Timer();
            overstimulatedTimer.Interval = 1000.0;
            overstimulatedTimer.AutoReset = true;
            overstimulatedTimer.Elapsed += Timer_Elapsed;
            overstimulatedTimer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Hunger -= .005f;
                Thirst -= .007f;
                Sleepy -= .004f;
                Bored -= .004f;
                Overstimulated -= .0045f;
            });

            if (Hunger <= 0)
            {
                hungerTimer.Stop();
                Hunger = 0;
            }
            if (Hunger >= 1)
            {
                Hunger = 1;
            }

            if (Thirst <= 0)
            {
                thirstTimer.Stop();
                Thirst = 0;
            }
            if (Thirst >= 1)
            {
                Thirst = 1;
            }

            if (Sleepy <= 0)
            {
                sleepyTimer.Stop();
                Sleepy = 0;
            }
            if (Sleepy >= 1)
            {
                Sleepy = 1;
            }

            if (Bored <= 0)
            {
                boredTimer.Stop();
                Bored = 0;
            }
            if (Bored >= 1)
            {
                Bored = 1;
            }

            if (Overstimulated <= 0)
            {
                overstimulatedTimer.Stop();
                Overstimulated = 0;
            }
            if (Overstimulated >= 1)
            {
                Overstimulated = 1;
            }
        }

        //NAVIGATION BUTTONS
        private void KitchenButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Kitchen());
        }

        private void PlayroomButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Playroom());
        }

        private void BedroomButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bedroom());
        }

        private void MainPageButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void GiveZen(object sender, EventArgs e)
        {
            ZenButton.RotateTo(180, 800, Easing.CubicOut);
            Overstimulated = 1;
        }
    }
}