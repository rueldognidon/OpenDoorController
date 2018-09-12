using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OpenDoorController.Navigation
{
    public class CustomNavigationPage : NavigationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomNavigationPage"/> class.
        /// </summary>
        /// <param name="root">The root.</param>
        public CustomNavigationPage(Page root) : base(root)
        {
            this.BarBackgroundColor = Color.FromHex("#FFFFFF");
            this.BarTextColor = Color.FromHex("#FFFFFF");
            this.Icon = null;
        }
    }
}
