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
    public partial class ShowTrees : ContentPage
    {
        TreesViewModel viewModel;
        public ShowTrees()
        {
            InitializeComponent();
            viewModel = new TreesViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayTrees();
        }
        private void DisplayTrees()
        {
            var res = viewModel.GetAllTrees().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddTree());
        }
        private void btnACatalogue_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Catalogue());
        }
        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                TreeInfo obj = (TreeInfo)e.SelectedItem;
                string res = await DisplayActionSheet("Select Action", "Cancel", null, "Update", "Delete", "Details");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddTree(obj));
                        break;
                    case "Delete":
                        viewModel.DeleteTree(obj);
                        DisplayTrees();
                        break;

                    case "Details":
                        await this.Navigation.PushAsync(new TreeDetail(obj));
                        break;

                }
                lstData.SelectedItem = null;
            }
           
        }
    
        }
    }
