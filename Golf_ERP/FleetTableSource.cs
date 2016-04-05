using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace Golf_ERP
{
    public class FleetTableSource : UITableViewSource
    {
        List<Cart> cartTableItems;
        string cellIdentifier = "CartCell";

        UIViewController parentController;

        public FleetTableSource(List<Cart> items, UIViewController parentController)
        {
            this.parentController = parentController;
            cartTableItems = items;//makes the input items equal to the private variable tableitems
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //in a storyboard, dequeue will always return a cell,
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            cell.TextLabel.Text = cartTableItems[indexPath.Row].Fleet_No;

            //Set cell accessory to disclosure to indicate the user can click it and move to the next page 
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            throw new NotImplementedException();
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //var might redirect to a detail page from here
            var selectedTask = cartTableItems[indexPath.Row];

            //MasterViewController mainController = (MasterViewController)parentController;

            //then open the detail view to edit it
            //var detail = parentController.Storyboard.InstantiateViewController("detail")
            //       as TaskDetailViewController;

            //set the selected task here
            //detail.SetTask(mainController, selectedTask);
            //parentController.NavigationController.PushViewController(detail, true);
        }
    }
}
