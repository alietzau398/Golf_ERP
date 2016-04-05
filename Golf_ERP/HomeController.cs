using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Parse;

namespace Golf_ERP
{
	partial class HomeController : UIViewController
	{
		public HomeController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (ParseUser.CurrentUser != null)
            {
                //navigate to welcome page,
                var welcome = Storyboard.InstantiateViewController("Welcome") as WelcomeController;
                NavigationController.PushViewController(welcome, true);

            }
        }

        async partial void BtnLogin_TouchUpInside(UIButton sender)
        {
            //to prevent the user from clicking on the button multiple times, 
            //I will hide my login button when it is clicked untill all the processing is complete
            btnLogin.Hidden = true;
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var error = "Enter a valid username and password";

            var alert = new UIAlertView();

            //if email and password is not provided, don't make a parse call
            if ((string.IsNullOrEmpty(username)) || (string.IsNullOrEmpty(password)))
            {
                alert = new UIAlertView("Login Failed", error, null, "OK");
                alert.Show();
            } else
            {
                //there is a username and password 
                try
                {
                    //you only need this one line to authenticate the user against parse
                    ParseUser myUser = await ParseUser.LogInAsync(username, password);
                    //alert = new UIAlertView("Login successful","Try looking at the navigation next", null, "OK");
                    //alert.Show();
                    //navigate to the welcome page,
                    //note: welcome is the storyboard ID of the welcomecontroller
                    var welcome = Storyboard.InstantiateViewController("Welcome") as WelcomeController;
                    NavigationController.PushViewController(welcome, true);
                    //var welcome = Storyboard.InstantiateViewController("welcome") as WelcomeController;
                    //NavigationController.PushViewController(welcome, true);
                }
                catch (ParseException f)
                {
                    var errorM = f.Message;
                    alert = new UIAlertView("Login Failed", error + " " + errorM , null, "OK");
                    alert.Show();
                } catch (Exception f)
                {
                    var errorM = f.Message;
                    alert = new UIAlertView("Login Failed", "Check your network access! or try again later." + " " + errorM, null, "OK");
                    alert.Show();
                }

            }
            //now I will display my login button 
            btnLogin.Hidden = false;
        }
    }
}
