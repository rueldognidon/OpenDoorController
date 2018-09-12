using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenDoorController.Navigation
{
    public interface IStackNavigator
    {
        /// <summary>
        /// Default Navigation Root view 
        /// </summary>
        CustomNavigationPage NavigationRootView { get; }

        /// <summary>
        /// Get the main page of the Navigation root view, resolved from RootViewName
        /// </summary>
        Page RootView { get; }

        /// <summary>
        /// Default main-page/root-page
        /// </summary>
        string RootViewName { get; set; }

        /// <summary>
        /// Navigate back to the last page before the current page.
        /// </summary>
        /// <param name="parameter">Object to send back to previous page</param>
        /// <returns>An await-able task.</returns>
        Task PopAsync(object parameter = null);

        /// <summary>
        /// Navigate back to the last page before the current page.
        /// </summary>
        /// <param name="parameter">Object to send back to previous page</param>
        /// <param name="animated">Enable or disable Animation</param>
        /// <returns>An await-able task.</returns>
        Task PopAsync(bool animated, object parameter = null);

        /// <summary>
        /// Navigate to the new page
        /// </summary>
        /// <param name="page">The new page to navigate to</param>
        /// <param name="animated">Enable or disable Animation</param>
        /// <returns>An await-able Task</returns>
        Task PushAsync(Page page, bool animated = true);

        /// <summary>
        /// Navigate towards the view based on the viewname 
        /// </summary>
        /// <param name="viewName" cref="ViewNames">The name of the new page based on <c>ViewNames</c></param>
        /// <param name="parameter">an object containing any data that will be passed the next view-model initialization method</param>
        /// <returns>Task that can be awaited</returns>
        Task PushAsync(string viewName, object parameter = null);

        /// <summary>
        /// Navigate towards the view based on the viewname 
        /// </summary>
        /// <param name="viewName" cref="ViewNames">The name of the new page based on <c>ViewNames</c></param>
        /// <param name="parameter">an object containing any data that will be passed the next view-model initialization method</param>
        /// <returns>Task that can be awaited</returns>
        Task PushAsync(string viewName, bool animated, object parameter = null);

        /// <summary>
        /// Pops to root asynchronous.
        /// </summary>
        /// <returns>To the root view.</returns>
        Task PopToRootAsync(object parameter = null);

        /// <summary>
        /// Navigate back all the way to the root page of the stack and push to a new page (simply clearing all pages in-between the root and the new current page)
        /// </summary>
        /// <param name="viewName" cref="ViewNames">The name of the new page based on <c>ViewNames</c></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task PushToNewRootPage(string viewName, object parameter = null);
    }
}
