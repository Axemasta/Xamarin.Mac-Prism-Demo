using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;

namespace Prism
{
    public abstract class PrismApplicationDelegate : PrismApplicationDelegateBase
    {
        protected PrismApplicationDelegate()
            : base() { }

        /// <summary>
        /// Creates the <see cref="IContainerExtension"/> for DryIoc
        /// </summary>
        /// <returns></returns>
        protected override IContainerExtension CreateContainerExtension()
        {
            return new DryIocContainerExtension(new Container(CreateContainerRules()));
        }

        /// <summary>
        /// Create <see cref="Rules" /> to alter behavior of <see cref="IContainer" />
        /// </summary>
        /// <returns>An instance of <see cref="Rules" /></returns>
        protected virtual Rules CreateContainerRules() => DryIocContainerExtension.DefaultRules;
    }
}
