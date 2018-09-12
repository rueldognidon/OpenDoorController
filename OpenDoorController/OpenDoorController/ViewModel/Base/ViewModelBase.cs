using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OpenDoorController.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Used for setting view-model properties with accompanying raise property changed from <c>INotifyPropertyChanged</c>
        /// </summary>
        /// <typeparam name="U">Property Type</typeparam>
        /// <param name="backingStore">reference field</param>
        /// <param name="value">new value</param>
        /// <param name="propertyName">name of the property (Defaults to CallerMemberName)</param>
        /// <param name="onChanged">Action for handling Changed Event</param>
        /// <param name="onChanging">Action executed before changing the value of the property</param>
        protected void Set<U>(ref U backingStore, U value, [CallerMemberName]string propertyName = null, Action onChanged = null, Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value)) return;

            onChanging?.Invoke(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Event-handler for property is changing
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Method for raising the property changing event
        /// </summary>
        /// <param name="propertyName">Name for the Property (Defaults to Caller Member)</param>
        public void OnPropertyChanging([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanging == null) return;

            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>
        /// Event-handler for property is already changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method for raising property changed event
        /// </summary>
        /// <param name="propertyName">Name for the Property (Defaults to Caller Member)</param>
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
