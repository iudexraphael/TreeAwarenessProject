using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeAwareness
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new View.FirstHomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
