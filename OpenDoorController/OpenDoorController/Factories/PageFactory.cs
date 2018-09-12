using Autofac;
using Autofac.Core.Registration;
using System;
using System.Collections.Generic;
using System.Text;
using OpenDoorController.ViewModel.Base;
using OpenDoorController.Views.Base;
using Xamarin.Forms;

namespace OpenDoorController.Factories
{
    public class PageFactory : IPageFactory
    {
        private readonly ILifetimeScope _scope;

        public PageFactory(ILifetimeScope scope)
        {
            this._scope = scope;
        }

        /// <summary>
        /// Resolves Pages for Navigation and Attaches a Resolved ViewModel
        /// </summary>
        /// <param name="viewName">Name of the Page as it is registered from the IOC</param>
        /// <param name="parameter">Object parameter that the page will consume, usually from linked pages</param>
        /// <returns>Xamarin Forms Page with binded ViewModel</returns>
        /// <exception cref="PageNotYetImplementedException"><paramref name="viewName"/> is not yet registered on the Autofac IOC.</exception>
        public Page GetPageWithInitializedViewModel(string viewName, object parameter = null)
        {
            try
            {
                var page = this._scope.ResolveNamed<Page>(viewName);

                page.BindingContext = this._scope.Resolve((page as IViewModelTypeExposed).ViewModelType);
                //var test = this._scope.Resolve((page as IViewModelTypeExposed).ViewModelType);
                if (page.BindingContext is MobileViewModelBase viewModel) viewModel.InitParams(parameter);

                return page;
            }
            catch (ComponentNotRegisteredException cnrex)
            {
                throw new PageNotYetImplementedException($"Page named {viewName} is not yet implemented.", cnrex);
            }
        }
    }
}
