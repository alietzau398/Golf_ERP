using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Parse;

namespace Golf_ERP
{
	partial class WelcomeController : UIViewController
	{
		public WelcomeController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //on page load, we will show the current user's first name from parse
            var currentUser = ParseUser.CurrentUser;
            lblWelcome.Text = "Welcome, " + currentUser["fName"];
        }

        partial void BtnLogOff_TouchUpInside(UIButton sender)
        {
            ParseUser.LogOut();
            NavigationController.PopViewController(true);
        }
    }
}
