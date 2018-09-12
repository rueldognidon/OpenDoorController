using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OpenDoorController.Factories
{
    public interface IPageFactory
    {
        Page GetPageWithInitializedViewModel(string viewName, object parameter = null);
    }
}
