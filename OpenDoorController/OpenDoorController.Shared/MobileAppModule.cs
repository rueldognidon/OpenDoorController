using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using OpenDoorController.AppConstants;
using OpenDoorController.Factories;
using OpenDoorController.Navigation;
using OpenDoorController.ViewModel.Login;
using OpenDoorController.Views.Login;
using Xamarin.Forms;

namespace OpenDoorController.Shared
{
    public class MobileAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterUI(builder);
            RegisterUtilities(builder);
            RegisterFactories(builder);
            RegisterManagers(builder);
            RegisterServices(builder);
        }

        private void RegisterUI(ContainerBuilder builder)
        {
            builder.RegisterType<OpenDoorControllerApp>().As<OpenDoorControllerApp>().SingleInstance();
            builder.RegisterType<LoginPage>().Named<Page>(ViewNames.LoginPage).InstancePerDependency();
            builder.RegisterType<LoginPageViewModel>().AsSelf();

            builder.RegisterType<NextPage>().Named<Page>(ViewNames.NextPage).InstancePerDependency();
            builder.RegisterType<NextPageViewModel>().AsSelf();
        }
        private void RegisterUtilities(ContainerBuilder builder)
        {
            builder.RegisterType<StackNavigator>().As<IStackNavigator>().SingleInstance();
        }

        private void RegisterFactories(ContainerBuilder builder)
        {
            builder.RegisterType<PageFactory>().As<IPageFactory>().SingleInstance();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
        }

        private void RegisterManagers(ContainerBuilder builder)
        {
        }
    }
}
