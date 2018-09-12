using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenDoorController.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OpenDoorController
{
    public partial class OpenDoorControllerApp : Application
    {
        private ILifetimeScope _scope;
        private IStackNavigator _navigator;

        public OpenDoorControllerApp()
        {
            InitializeComponent();


        }

        public void SetLifetimeScope(ILifetimeScope scope)
        {
            this._scope = scope;
            this._navigator = scope.Resolve<IStackNavigator>();


            this.InitializeMainPage();

        }

        private void InitializeMainPage()
        {
            this.MainPage = this._navigator.NavigationRootView;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
