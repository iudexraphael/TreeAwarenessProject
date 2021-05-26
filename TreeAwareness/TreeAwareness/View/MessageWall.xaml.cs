using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAwareness.Model;
using TreeAwareness.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeAwareness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageWall : ContentPage
    {
        MessageViewModel viewModel;
        public MessageWall()
        {
            InitializeComponent();
            viewModel = new MessageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayMessages();
        }
        private void DisplayMessages()
        {
            var res = viewModel.GetAllMessages().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddMessage());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                UserMessages obj = (UserMessages)e.SelectedItem;
                string res = await DisplayActionSheet("Select Action", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddMessage(obj));
                        break;
                    case "Delete":
                        viewModel.DeleteMessage(obj);
                        DisplayMessages();
                        break;

                 

                }
                lstData.SelectedItem = null;
            }

        }
    
    }
}
