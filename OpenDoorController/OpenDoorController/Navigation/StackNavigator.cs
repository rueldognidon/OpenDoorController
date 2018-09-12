using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenDoorController.AppConstants;
using OpenDoorController.Factories;
using OpenDoorController.ViewModel.Base;
using Xamarin.Forms;

namespace OpenDoorController.Navigation
{
    public class StackNavigator : IStackNavigator
    {
        #region Fields

        private readonly IPageFactory _pageFactory;

        #endregion Fields

        /// <summary>
        /// Default main-page/root-page
        /// </summary>
#if DEBUG
        public string RootViewName { get; set; } = ViewNames.LoginPage;
        //public string RootViewName { get; set; } = ViewNames.ProfilePage;



#else
        public string RootViewName { get; set; } = ViewNames.LoginPage;
        //public string RootViewName { get; set; } = ViewNames.MainPage;
#endif

        /// <summary>
        /// Default Navigation Root view 
        /// </summary>
        private CustomNavigationPage _navigationRootView;
        public CustomNavigationPage NavigationRootView
        {
            get
            {
                if (this._navigationRootView == null)
                {
                    this._navigationRootView = new CustomNavigationPage(this.RootView);
                    this._navigationRootView.Popped += _navigationRootView_Popped;
                    this._navigationRootView.PoppedToRoot += _navigationRootView_PoppedToRoot;
                }

                return this._navigationRootView;
            }
        }
        private object popToRootParameter = null;
        private void _navigationRootView_PoppedToRoot(object sender, NavigationEventArgs e)
        {
            if (this.NavigationRootView.CurrentPage.BindingContext is MobileViewModelBase viewModel)
            {
                viewModel.NextPagePopped(popToRootParameter);
            }
        }

        private object popParameter = null;
        private void _navigationRootView_Popped(object sender, NavigationEventArgs e)
        {
            if (this.NavigationRootView.CurrentPage.BindingContext is MobileViewModelBase viewModel)
            {
                viewModel.NextPagePopped(popParameter);
            }
        }

        /// <summary>
        /// Get the main page of the Navigation root view, resolved from RootViewName
        /// </summary>
        public Page RootView
        {
            get { return this._pageFactory.GetPageWithInitializedViewModel(this.RootViewName); }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="pageFactory">Page factory for resolving pages</param>
        public StackNavigator(IPageFactory pageFactory)
        {
            this._pageFactory = pageFactory;
        }

        /// <summary>
        /// Navigate towards the view based on the viewname 
        /// </summary>
        /// <param name="viewName">The name of the new page based on <see cref="ViewNames"/></param>
        /// <param name="parameter">an object containing any data that will be passed the next view-model initialization method</param>
        /// <returns>Task that can be awaited</returns>
        public async Task PushAsync(string viewName, object parameter = null)
        {
            try
            {
                var page = this._pageFactory.GetPageWithInitializedViewModel(viewName, parameter);

                await PushAsync(page);
            }
            catch (PageNotYetImplementedException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Navigate towards the view based on the viewname 
        /// </summary>
        /// <param name="viewName">The name of the new page based on <see cref="ViewNames"/></param>
        /// <param name="parameter">an object containing any data that will be passed the next view-model initialization method</param>
        /// <returns>Task that can be awaited</returns>
        public async Task PushAsync(string viewName, bool animated, object parameter = null)
        {
            try
            {
                var page = this._pageFactory.GetPageWithInitializedViewModel(viewName, parameter);

                await PushAsync(page, animated);
            }
            catch (PageNotYetImplementedException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Navigate to the new page
        /// </summary>
        /// <param name="page">The new page to navigate to</param>
        /// <returns>An await-able Task</returns>
        public async Task PushAsync(Page page, bool animated = true)
        {
            await this.NavigationRootView?.PushAsync(page, animated);
        }


        /// <summary>
        /// Navigate back to the last page before the current page.
        /// </summary>
        /// <returns>An await-able task.</returns>
        public async Task PopAsync(object parameter = null)
        {
            popParameter = parameter;
            await this.NavigationRootView?.PopAsync();
        }

        /// <summary>
        /// Navigate back to the last page before the current page.
        /// </summary>
        /// <returns>An await-able task.</returns>
        public async Task PopAsync(bool animated, object parameter = null)
        {
            popParameter = parameter;
            await this.NavigationRootView?.PopAsync(animated);
        }

        /// <summary>
        /// Pops to root asynchronous.
        /// </summary>
        /// <returns>To the root view.</returns>
        public async Task PopToRootAsync(object parameter = null)
        {
            popToRootParameter = parameter;
            await this.NavigationRootView.PopToRootAsync();
        }

        /// <summary>
        /// Navigate back all the way to the root page of the stack and push to a new page (simply clearing all pages in-between the root and the new current page)
        /// </summary>
        /// <param name="viewName" cref="ViewNames">The name of the new page based on <c>ViewNames</c></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task PushToNewRootPage(string viewName, object parameter = null)
        {
            try
            {
                var page = this._pageFactory.GetPageWithInitializedViewModel(viewName, parameter);

                var nav = this.NavigationRootView.Navigation;

                var rootPage = nav.NavigationStack[nav.NavigationStack.Count - 1];

                nav.InsertPageBefore(page, rootPage);

                this.RootViewName = viewName;

                await this.NavigationRootView.PopToRootAsync();
            }
            catch (PageNotYetImplementedException ex)
            {
                throw ex;
            }
        }
    }
}
