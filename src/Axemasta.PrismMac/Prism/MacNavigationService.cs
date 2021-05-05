using System;
using System.Threading.Tasks;
using AppKit;
using Axemasta.PrismMac;
using Foundation;
using Prism.Ioc;
using Prism.Navigation;

namespace Prism
{
    public class MacNavigationService : INativeNavigationService
    {
        private readonly IContainerProvider _container;

        public MacNavigationService(IContainerProvider container)
        {
            _container = container;
        }

        public Task<INavigationResult> NavigateAsync(string viewController, NSObject sender)
        {
            return NavigateInternal(viewController, sender);
            
        }

        protected async virtual Task<INavigationResult> NavigateInternal(string identifier, NSObject sender)
        {
            var result = new NavigationResult();

            try
            {
                await ProcessNavigation(identifier, sender);
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                return result;
            }
        }

        protected virtual async Task ProcessNavigation(string identifier, NSObject sender)
        {
            /* TODO: Figure out if I can new up view controllers & satisfy their dependencies?
             *       Maybe I will have to have to autowire viewmodels and not allow resolution from a vc
             */

            // Get new window
            var storyboard = NSStoryboard.FromName("Main", null);
            var controller = storyboard.InstantiateControllerWithIdentifier(identifier) as NSWindowController;

            // Display
            controller.ShowWindow(sender);
        }
    }
}
