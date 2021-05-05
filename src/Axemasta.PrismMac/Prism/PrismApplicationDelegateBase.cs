using System.Diagnostics;
using AppKit;
using Prism.Events;
using Prism.Ioc;

namespace Prism
{
    public abstract class PrismApplicationDelegateBase : NSApplicationDelegate
    {
        public static NSApplicationDelegate _current { get; set; }

        public static void SetCurrentApplication(NSApplicationDelegate value) => _current = value;

        public new static PrismApplicationDelegateBase Current => (PrismApplicationDelegateBase)_current;

        private IContainerExtension _containerExtension;

        /// <summary>
        /// The dependency injection container used to resolve objects
        /// </summary>
        public IContainerProvider Container => _containerExtension;

        public PrismApplicationDelegateBase()
        {
            SetCurrentApplication(this);

            InitializeInternal();
        }

        private void InitializeInternal()
        {
            //ConfigureViewModelLocator();
            Initialize();
            OnInitialized();
        }

        protected virtual void Initialize()
        {
            Debug.WriteLine("Wire up container here!!!");

            ContainerLocator.SetContainerExtension(CreateContainerExtension);
            _containerExtension = ContainerLocator.Current;
            RegisterRequiredTypes(_containerExtension);
            RegisterTypes(_containerExtension);
            _containerExtension.FinalizeExtension();

            Debug.WriteLine("Container wired up!!!");
        }

        //protected virtual void ConfigureViewModelLocator()
        //{
        //    // Not Needed?
        //}

        /// <summary>
        /// Creates the container used by Prism.
        /// </summary>
        /// <returns>The container</returns>
        protected abstract IContainerExtension CreateContainerExtension();

        /// <summary>
        /// Called when the PrismApplication has completed it's initialization process.
        /// </summary>
        protected abstract void OnInitialized();

        /// <summary>
        /// Registers all types that are required by Prism to function with the container.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected virtual void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IEventAggregator, EventAggregator>();
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        protected abstract void RegisterTypes(IContainerRegistry containerRegistry);
    }
}
