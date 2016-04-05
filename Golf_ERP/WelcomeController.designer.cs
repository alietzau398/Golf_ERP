// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Golf_ERP
{
	[Register ("WelcomeController")]
	partial class WelcomeController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnFleet { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnLogOff { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblWelcome { get; set; }

		[Action ("BtnFleet_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnFleet_TouchUpInside (UIButton sender);

		[Action ("BtnLogOff_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnLogOff_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnFleet != null) {
				btnFleet.Dispose ();
				btnFleet = null;
			}
			if (btnLogOff != null) {
				btnLogOff.Dispose ();
				btnLogOff = null;
			}
			if (lblWelcome != null) {
				lblWelcome.Dispose ();
				lblWelcome = null;
			}
		}
	}
}
