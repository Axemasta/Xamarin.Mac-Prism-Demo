// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Axemasta.PrismMac
{
	[Register ("ViewController")]
	partial class MyViewController
	{
		[Outlet]
		AppKit.NSTextField coolLabel { get; set; }

		[Action ("coolButtonAction:")]
		partial void coolButtonAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (coolLabel != null) {
				coolLabel.Dispose ();
				coolLabel = null;
			}
		}
	}
}
