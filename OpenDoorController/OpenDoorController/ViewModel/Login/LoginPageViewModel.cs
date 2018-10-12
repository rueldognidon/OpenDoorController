using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using OpenDoorController.AppConstants;
using OpenDoorController.Navigation;
using OpenDoorController.ViewModel.Base;
using Plugin.BluetoothLE;
using Xamarin.Forms;

namespace OpenDoorController.ViewModel.Login
{
    public class LoginPageViewModel : MobileViewModelBase
    {
        public LoginPageViewModel(IStackNavigator navigator) : base(navigator)
        {
        }

        private string _scanResult;

        public string ScanResult
        {
            get { return _scanResult; }
            set { this.Set(ref _scanResult, value); }
        }

        public ICommand ScanBluetoothCommand
        {
            get { return new Command(ScanBluetooth); }
        }

        private void ScanBluetooth()
        {
            // discover some devices
            
            CrossBleAdapter.Current.Scan().Subscribe(scanResult => 
            {
                if(scanResult.Device.Name == "ERNI_MALE_TOILET")
                {
                    // Once finding the device/scanresult you want
                    scanResult.Device.Connect();

                    ScanResult = scanResult.Device.Name;
                }

            });


            //scanResult.Device.WhenAnyCharacteristicDiscovered().Subscribe(characteristic =>
            //{
            //    // read, write, or subscribe to notifications here
            //    var result = await characteristic.Read(); // use result.Data to see response
            //    await characteristic.Write(bytes);

            //    characteristic.EnableNotifications();
            //    characteristic.WhenNotificationReceived().Subscribe(result =>
            //    {
            //        //result.Data to get at response
            //    });
            //});
        }        
    }
}
