using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDoorController.Views.Base
{
    public interface IViewModelTypeExposed
    {
        /// <summary>
        /// Viewmodel type/class for binding resolution on IOC
        /// </summary>
        Type ViewModelType { get; }
    }
}
