using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using OpenDoorController.Shared;

namespace OpenDoorController.Droid
{
    [Activity(Label = "OpenDoorController", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private OpenDoorControllerApp _app;
        private IContainer scope;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            InitializeContainer();
            LoadApplication(this._app);
        }

        private void InitializeContainer()
        {

            ContainerBuilder containerBuilder = new ContainerBuilder();

#pragma warning disable CS0436 // Type conflicts with imported type
            containerBuilder.RegisterModule(new MobileAppModule());
#pragma warning restore CS0436 // Type conflicts with imported type

            this.scope = containerBuilder.Build();

            var appLifetimeScope = this.scope.BeginLifetimeScope();

            this._app = appLifetimeScope.Resolve<OpenDoorControllerApp>();

            this._app.SetLifetimeScope(appLifetimeScope);
        }
    }
}

