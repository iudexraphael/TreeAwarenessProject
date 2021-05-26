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
    public partial class TreeDetail : ContentPage
    {
        TreesViewModel _viewModel;
        bool _isUpdate;
        int treeID;
      
        public TreeDetail()
        {
            InitializeComponent();
            _viewModel = new TreesViewModel();
            _isUpdate = false;
        }
        public TreeDetail(TreeInfo obj)
        {
            InitializeComponent();
            _viewModel = new TreesViewModel();
            if (obj != null)
            {
                treeID = obj.TreeCode;
                txtName.Text = obj.Name;
                txtIdentity.Text = obj.InitialIdentification;
                txtNote.Text = obj.Notes;
                txtCoordinates.Text = obj.GPSCoordinates;
                txtLocation.Text = obj.Location;
                txtLandmark.Text = obj.Landmark;
                txtHeight.Text = obj.Height;
                txtCanopy.Text = obj.Canopy;
                _isUpdate = true;
            }

        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            TreeInfo obj = new TreeInfo();
            obj.Name = txtName.Text;
            obj.InitialIdentification = txtIdentity.Text;
            obj.Notes = txtNote.Text;
            obj.GPSCoordinates = txtCoordinates.Text;
            obj.Location = txtLocation.Text;
            obj.Landmark = txtLandmark.Text;
            obj.Height = txtHeight.Text;
            obj.Canopy = txtCanopy.Text;
            if (_isUpdate)
            {
                obj.TreeCode = treeID;
                await _viewModel.UpdateTrees(obj);
            }
            else
            {
                _viewModel.InsertTree(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}