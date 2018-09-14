using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using OpenDoorController.Shared;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using Plugin.Permissions;
using Android.Bluetooth;

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

        protected override void OnStart()
        {
            base.OnStart();


            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted && 
                ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted &&
                ContextCompat.CheckSelfPermission(this, Manifest.Permission.Bluetooth) != Android.Content.PM.Permission.Granted &&
                ContextCompat.CheckSelfPermission(this, Manifest.Permission.BluetoothAdmin) != Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] 
                { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation, Manifest.Permission.Bluetooth, Manifest.Permission.BluetoothAdmin }, 0);                                            
            }

            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            if (!bluetoothAdapter.IsEnabled)
            {
                bluetoothAdapter.Enable();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

