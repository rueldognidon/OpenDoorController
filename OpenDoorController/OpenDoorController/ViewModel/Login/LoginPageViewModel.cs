using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using OpenDoorController.AppConstants;
using OpenDoorController.Navigation;
using OpenDoorController.ViewModel.Base;
using Xamarin.Forms;

namespace OpenDoorController.ViewModel.Login
{
    public class LoginPageViewModel : MobileViewModelBase
    {
        public LoginPageViewModel(IStackNavigator navigator) : base(navigator)
        {
        }

        public ICommand NextPageCommand
        {
            get { return new Command(this.GoToNextPage); }
        }

        private void GoToNextPage()
        {
            this.Navigator.PushAsync(ViewNames.NextPage);
        }
    }
}
