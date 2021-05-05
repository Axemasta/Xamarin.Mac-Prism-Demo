using System;
using System.Threading.Tasks;
using Foundation;
using Prism.Navigation;

namespace Prism
{
    public interface INativeNavigationService
    {
        Task<INavigationResult> NavigateAsync(string viewController, NSObject sender);
    }
}
