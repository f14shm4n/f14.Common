using System.Runtime.CompilerServices;

namespace System.ComponentModel
{
    /// <summary>
    /// Provides a implementation of the <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public class NotifyModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        public event PropertyChangingEventHandler? PropertyChanging;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for given property names.
        /// </summary>
        /// <param name="properyNames">The desired property names.</param>
        public void RefreshProperties(params string[] properyNames)
        {
            if (properyNames is null)
            {
                return;
            }

            if (PropertyChanged == null)
            {
                return;
            }

            foreach (var pName in properyNames)
            {
                if (pName is not null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(pName));
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> for given property name.
        /// </summary>
        /// <param name="name"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        /// <summary>
        /// Raises the <see cref="PropertyChanging"/> for given property name.
        /// </summary>
        /// <param name="name"></param>
        protected virtual void OnPropertyChanging([CallerMemberName] string name = "") => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));

        /// <summary>
        /// Sets the value to specified property.
        /// </summary>
        /// <typeparam name="T">Type of the property value.</typeparam>
        /// <param name="currentValue">The reference to the property.</param>
        /// <param name="newValue">The new property value to assign.</param>
        /// <param name="property">The property name.</param>
        protected void OnSet<T>(ref T currentValue, T newValue, [CallerMemberName] string property = "")
        {
            if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
            {
                OnPropertyChanging(property);
                currentValue = newValue;
                OnPropertyChanged(property);
            }
        }
    }
}
