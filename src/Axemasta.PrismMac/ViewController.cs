using System;

using AppKit;
using Axemasta.PrismMac.Services;
using Foundation;
using Prism;
using Prism.Ioc;

namespace Axemasta.PrismMac
{
    public partial class ViewController : NSViewController
    {
        private readonly ICoolService _coolService;

        public ViewController(IntPtr handle) : base(handle)
        {
            var container = AppDelegate.Current.Container;

            _coolService = container.Resolve<ICoolService>();
            _coolService.DoSomething();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
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
