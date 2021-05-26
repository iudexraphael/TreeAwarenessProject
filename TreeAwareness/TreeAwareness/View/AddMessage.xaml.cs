using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreeAwareness.Model;
using TreeAwareness.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeAwareness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMessage : ContentPage
    {
        MessageViewModel _viewModel;
        bool _isUpdate;
        int messagecount;
        public AddMessage()
        {
            InitializeComponent();
            _viewModel = new MessageViewModel();
            _isUpdate = false;
        }
        public AddMessage(UserMessages obj)
        {
            InitializeComponent();
            _viewModel = new MessageViewModel();
            if (obj != null)
            {
                messagecount = obj.messageID;
                txtcommentname.Text = obj.Username;
                txtcomment.Text = obj.Comment;
                TreePick.Text = obj.Image;
                  _isUpdate = true;
            }

        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            UserMessages obj = new UserMessages();
            obj.Username = txtcommentname.Text;
            obj.Comment = txtcomment.Text;
            
            if (_isUpdate)
            {
                obj.messageID = messagecount;
                await _viewModel.UpdateMessages(obj);
            }
            else
            {
                _viewModel.InsertMessage(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}