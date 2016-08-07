﻿namespace BudgetFirst.Wrappers
{
    using System;
    using System.Collections.Generic;

    using GalaSoft.MvvmLight.Ioc;

    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Wrapper for Microsoft.Practices.ServiceLocation.ServiceLocator because using that in a PCL with code analysis enabled causes build errors.
    /// </summary>
    public class ServiceLocatorWrapper
    {
        /// <summary>
        /// Static instance
        /// </summary>
        private static ServiceLocatorWrapper instance = new ServiceLocatorWrapper();

        /// <summary>
        /// Initialises static members of the <see cref="ServiceLocatorWrapper"/> class.
        /// </summary>
        static ServiceLocatorWrapper()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        /// <summary>
        /// Gets the current locator
        /// </summary>
        public static ServiceLocatorWrapper Current => instance;

        /// <summary>
        /// Get all instances of the given <paramref name="serviceType" /> currently
        /// registered in the container.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>A sequence of instances of the requested <paramref name="serviceType" />.</returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return this.GetOriginal().GetAllInstances(serviceType);
        }

        /// <summary>
        /// Get all instances of the given <typeparamref name="TService" /> currently
        /// registered in the container.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>A sequence of instances of the requested <typeparamref name="TService" />.</returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return this.GetOriginal().GetAllInstances<TService>();
        }

        /// <summary>
        /// Get an instance of the given <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public object GetInstance(Type serviceType)
        {
            return this.GetOriginal().GetInstance(serviceType);
        }

        /// <summary>
        /// Get an instance of the given named <paramref name="serviceType" />.
        /// </summary>
        /// <param name="serviceType">Type of object requested.</param>
        /// <param name="key">Name the object was registered with.</param>
        /// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public object GetInstance(Type serviceType, string key)
        {
            return this.GetOriginal().GetInstance(serviceType, key);
        }

        /// <summary>
        /// Get an instance of the given <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public TService GetInstance<TService>()
        {
            return this.GetOriginal().GetInstance<TService>();
        }

        /// <summary>
        /// Get an instance of the given named <typeparamref name="TService" />.
        /// </summary>
        /// <typeparam name="TService">Type of object requested.</typeparam>
        /// <param name="key">Name the object was registered with.</param>
        /// <exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
        /// the service instance.</exception>
        /// <returns>The requested service instance.</returns>
        public TService GetInstance<TService>(string key)
        {
            return this.GetOriginal().GetInstance<TService>(key);
        }

        /// <summary>Gets the service object of the specified type.</summary>
        /// <returns>A service object of type <paramref name="serviceType" />.-or- null if there is no service object of type <paramref name="serviceType" />.</returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param>
        /// <filterpriority>2</filterpriority>
        public object GetService(Type serviceType)
        {
            return this.GetOriginal().GetService(serviceType);
        }

        /// <summary>
        /// Get wrapped service locator
        /// </summary>
        /// <returns>Get original service locator</returns>
        private IServiceLocator GetOriginal()
        {
            return ServiceLocator.Current;
        }

        /// <summary>
        /// Initialise the service locator
        /// </summary>
        public void InitialiseServiceLocator()
        {
            // Initialisation is done once the static type is loaded.
        }
    }
}