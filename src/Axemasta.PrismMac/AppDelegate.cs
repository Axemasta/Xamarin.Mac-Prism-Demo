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
        protected override void OnInitialized()
        {
            //var coolService = Container.Resolve<ICoolService>();
            //coolService.DoSomething();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICoolService, CoolService>();
        }
    }
}
