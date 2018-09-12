using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using OpenDoorController.Factories;
using OpenDoorController.Navigation;
using Xamarin.Forms;

namespace OpenDoorController.ViewModel.Base
{
    public class MobileViewModelBase : ViewModelBase, IDisposable
    {
        public MobileViewModelBase()
        {
        }
        #region Properties

        /// <summary>
        /// Default Navigator for Pushing and Popping Pages
        /// </summary>
        public IStackNavigator Navigator { get; set; }

        /// <summary>
        /// Flag that is <c>true</c> when InitParams methods is already called.
        /// </summary>
        public bool IsInitialized { get; set; }

        private bool _canLoadMore;
        /// <summary>
        /// Flag that is <c>true</c> when data can be fetched.
        /// </summary>
        public bool CanLoadMore
        {
            get { return this._canLoadMore; }
            set { Set(ref this._canLoadMore, value); }
        }

        private bool _isBusy;
        /// <summary>
        /// Flag that is <c>true</c> when a Task is running.
        /// </summary>
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { Set(ref this._isBusy, value); }
        }

        private string _title = string.Empty;
        /// <summary>
        /// Page title.
        /// </summary>
        public string Title
        {
            get { return this._title; }
            set { Set(ref this._title, value); }
        }

        string _subTitle = string.Empty;
        /// <summary>
        /// Page subtitle.
        /// </summary>
        public string Subtitle
        {
            get { return this._subTitle; }
            set { Set(ref this._subTitle, value); }
        }

        string _icon = null;
        /// <summary>
        /// Inheritable property for setting View/ContentPage Icon.
        /// </summary>
        public string Icon
        {
            get { return this._icon; }
            set { Set(ref this._icon, value); }
        }

        #endregion Properties

        #region Commands

        /// <summary>
        /// Default command for going back to previous page.
        /// </summary>
        public ICommand BackCommand
        {
            get { return new Command(this.Back); }
        }

        protected Command<string> _navigateCommand;

        /// <summary>
        /// Command for navigation triggered from View
        /// </summary>
        public ICommand NavigateCommand => this._navigateCommand;

        /// <summary>
        /// Method that is executed when Navigate Command is triggered.
        /// </summary>
        /// <param name="viewName">Name of the view to navigate to</param>
        public void ExecuteNavigateCommand(string viewName) => Navigate(viewName);

        /// <summary>
        /// Check method if a view can be navigated to
        /// </summary>
        /// <param name="viewName">Name of the view to check for allowable navigation</param>
        /// <returns>True if view is navigable</returns>
        public bool CanExecuteNavigateCommand(string viewName)
        {
            return true;
        }
        #endregion Commands

        #region Constructor
        public MobileViewModelBase(IStackNavigator navigator)
        {
            this.Navigator = navigator;

            this._navigateCommand = new Command<string>(this.ExecuteNavigateCommand, this.CanExecuteNavigateCommand);
        }
        #endregion Constructor

        /// <summary>
        /// Initialize the view-model based on the parameter sent from the preview view/view-model.
        /// </summary>
        /// <param name="parameter">Object that contains all/any mutable data that the view-model needs for initialization.</param>
        public virtual void InitParams(object parameter)
        {

        }

        public virtual void NextPagePopped(object parameter)
        {
        }

        /// <summary>
        /// Exposed navigation method that uses the Navigator of the view for Navigation.
        /// </summary>
        /// <param name="viewName"></param>
        public async void Navigate(string viewName)
        {
            try
            {
                await this.Navigator.PushAsync(viewName);
            }
            catch (PageNotYetImplementedException ex)
            {
                OnPopupMessage(ex.Message);
            }
        }

        /// <summary>
        /// Used for displaying pop-up message using IUserDialogs.
        /// </summary>
        /// <param name="message">the message on the pop-up.</param>
        public virtual void OnPopupMessage(string message)
        {

        }


        public virtual async void Back()
        {
            await this.Navigator.PopAsync();
        }

        public virtual void Dispose()
        {

        }

    }
}
