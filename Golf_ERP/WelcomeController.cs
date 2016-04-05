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

            //remove the back button so log in page will not be accessed.
            this.NavigationItem.SetHidesBackButton(true, false);


            //on page load, we will show the current user's first name from parse
            var currentUser = ParseUser.CurrentUser;
            lblWelcome.Text = "Welcome, " + currentUser["fName"];
        }

        partial void BtnLogOff_TouchUpInside(UIButton sender)
        {
            ParseUser.LogOut();
            var home = Storyboard.InstantiateViewController("home") as HomeController;
            NavigationController.PushViewController(home, true);
        }
    }
}
