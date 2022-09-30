using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace Tamagotchi
{
    public partial class MainPage : ContentPage
    {
        //het is niet gelukt om de status-progress bars consistent te laten leeglopen wanneer je tussen pagina's switched.
        //zoals te zien in de console werkten de status variables echter wel naar behoren, en lopen zo ook consistent leeg als je van pagina's switched.
        //voor showcase purposes in het filmpje heb ik dus de variabelen opnieuw aangemaakt in elk script. hopelijk verlicht dit de spaghetti-overload shock.

        //5 variables voor de status effect bars
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

        public MainPage()
        {
            BindingContext = this;

            InitializeComponent();

            //timer functionaliteit
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
                Hunger -= .005f; //deze 5 status effect variables blijven in de backend doortellen zelfs als er van page geswitched wordt.
                Thirst -= .007f; //dit geldt helaas niet voor de bijbehorende frontend progress-bars (de bars worden ge-reset on page PushAsync).
                Sleepy -= .004f;
                Bored -= .004f;
                Overstimulated -= .0045f;
            });

            //deze 5 console lines weergeven de 'true' status values van de tamagotchi; in tegenstelling tot de coloured progress-bars die je onderaan het scherm ziet.
            System.Diagnostics.Debug.WriteLine("HUNGER: " + Hunger);
            System.Diagnostics.Debug.WriteLine("THIRST: " + Thirst);
            System.Diagnostics.Debug.WriteLine("SLEEPY: " + Sleepy);
            System.Diagnostics.Debug.WriteLine("BORED: " + Bored);
            System.Diagnostics.Debug.WriteLine("OVERSTIMULATED: " + Overstimulated);

            //deze if-statements zorgen er voor dat de statussen nooit lager dan 0 (min.), of hoger dan 1 (max.) kunnen gaan.
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

        private void ZenroomButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Zenroom());
        }

        private void BedroomButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bedroom());
        }
    }
}
