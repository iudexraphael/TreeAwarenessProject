using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeAwareness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstHomePage : ContentPage
    {
        public FirstHomePage()
        {
            InitializeComponent();
        }
            private async void ProjNextPage(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ShowTrees());
            }
        private async void MessageNextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessageWall());
        }
        private async void AboutNextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutInfo());
        }
        private async void PlantAtGardenPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMessage());
        }
    }
    }
