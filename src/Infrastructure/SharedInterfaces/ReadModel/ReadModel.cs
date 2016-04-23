﻿namespace BudgetFirst.SharedInterfaces.ReadModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using Annotations;

    /// <summary>
    /// Base class for read models
    /// </summary>
    public abstract class ReadModel : IReadModel
    {
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set property and, if different than current value, raise <see cref="PropertyChanged"/>.
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="storage">Reference to backing object</param>
        /// <param name="value">New value to set</param>
        /// <param name="propertyName">(optional) name of the property, usually automatically resolved</param>
        /// <returns><c>true</c> if the property was changed</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (ReadModel.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Raise <see cref="PropertyChanged"/>
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
