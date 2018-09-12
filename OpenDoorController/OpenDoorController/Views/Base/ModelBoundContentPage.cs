using System;
using System.Collections.Generic;
using System.Text;
using OpenDoorController.ViewModel.Base;
using Xamarin.Forms;

namespace OpenDoorController.Views.Base
{
    /// <summary>
    /// A generically typed ContentPage that enforces the type of its BindingContext according to TViewModel.
    /// </summary>
    public abstract class ModelBoundContentPage<TViewModel> : ContentPage, IViewModelTypeExposed where TViewModel : MobileViewModelBase
    {
        /// <summary>
        /// Gets the generically typed ViewModel from the underlying BindingContext.
        /// </summary>
        /// <value>The generically typed ViewModel.</value>
        protected TViewModel ViewModel
        {
            get { return base.BindingContext as TViewModel; }
        }


        /// <summary>
        /// Sets the underlying BindingContext as the defined generic type.
        /// </summary>
        /// <value>The generically typed ViewModel.</value>
        /// <remarks>Enforces a generically typed BindingContext, instead of the underlying loosely object-typed BindingContext.</remarks>
        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged("BindingContext");
            }
        }

        /// <summary>
        /// Get the type of ViewModel for the view, this is for IOC implementation resolution purpose
        /// </summary>
        public Type ViewModelType
        {
            get { return typeof(TViewModel); }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ModelBoundContentPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

    }
}
