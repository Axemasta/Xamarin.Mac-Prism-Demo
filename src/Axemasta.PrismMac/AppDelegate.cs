using System.Diagnostics;
using AppKit;
using Axemasta.PrismMac.Services;
using Foundation;
using Prism;
using Prism.Ioc;

namespace Axemasta.PrismMac
{
    [Register("AppDelegate")]
    public class AppDelegate : PrismApplicationDelegate
    {
        protected override async void OnInitialized()
        {
            //var coolService = Container.Resolve<ICoolService>();
            //coolService.DoSomething();

            var nav = await NavigationService.NavigateAsync("MyMainWindow", this);

            if (!nav.Success)
            {
                Debug.WriteLine($"An exception occurred navigating: {nav.Exception}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICoolService, CoolService>();
        }
    }
}
