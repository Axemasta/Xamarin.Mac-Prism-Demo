using System;

using AppKit;
using Axemasta.PrismMac.Services;
using Foundation;
using Prism;
using Prism.Ioc;

namespace Axemasta.PrismMac
{
    public partial class MyViewController : NSViewController
    {
        private readonly ICoolService _coolService;

        public MyViewController(IntPtr handle) : base(handle)
        {
            //TODO: Yuck, move to a view model?
            var container = AppDelegate.Current.Container;

            _coolService = container.Resolve<ICoolService>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            coolLabel.StringValue = "";
        }

        partial void coolButtonAction(Foundation.NSObject sender)
        {
            // Update counter and label
            var cool = _coolService.GetSomething();

            coolLabel.StringValue = cool;
        }


        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
