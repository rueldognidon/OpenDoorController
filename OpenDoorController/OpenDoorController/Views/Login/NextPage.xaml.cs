using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDoorController.ViewModel.Login;
using OpenDoorController.Views.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenDoorController.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextPage : NextPageXaml
    {
        public NextPage()
        {
            InitializeComponent();
        }
    }

    public class NextPageXaml : ModelBoundContentPage<NextPageViewModel>
    {

    }
}