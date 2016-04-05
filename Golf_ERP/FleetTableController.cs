using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using UIKit;
using Parse;

namespace Golf_ERP
{
	partial class FleetTableController : UITableViewController
	{
        //initialize items to be used globally in the class
        List<Cart> cartList;

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //calls the method to get all the carts owned by the current user.
            try
            {
                await GetAllCarts();
            } catch (Exception ex)
            {
                new UIAlertView("Something went wrong!", ex.ToString(),null, "ok").Show();
            }


        }
        public FleetTableController (IntPtr handle) : base (handle)
		{
		}

        public async System.Threading.Tasks.Task GetAllCarts()
        {
            //initialize the list of carts related to the user
            cartList = new List<Cart> { };

            //get a list of tasks from parse and sort by uppdateAd Date
            var query = from cartsQuery in ParseObject.GetQuery("Carts")
                        where cartsQuery["User"] == ParseUser.CurrentUser
                        select cartsQuery;
            try
            {
                IEnumerable<ParseObject> cartListResults = await query.FindAsync();
                
                //if the returned list from parse is NOT empty
                if (cartListResults != null)
                {
                    //loop through the results and create 
                    foreach (var myCart in cartListResults)
                    {
                        var cartItem = new Cart()
                        {
                            //puts results from query into a new object called cartItem
                            ObjectID = myCart.ObjectId,
                            User = myCart.Get<ParseUser>("User"),
                            Fleet_No = myCart.Get<string>("Fleet_No"),
                            Barcode_String = myCart.Get<string>("Barcode_String"),
                            Year = myCart.Get<int>("Year"),
                            Brand = myCart.Get<string>("Brand"),
                            Model = myCart.Get<string>("Model"),
                            Notes = myCart.Get<string>("Notes"),
                            Id = cartList.Count + 1,
                        };
                        //adds cartItem to the List
                        cartList.Add(cartItem);
                    }
                }
            }
            catch (Exception ex)
            {
                new UIAlertView("Something went wrong!", ex.ToString(), null, "ok").Show();
            }
        }
    }
}
