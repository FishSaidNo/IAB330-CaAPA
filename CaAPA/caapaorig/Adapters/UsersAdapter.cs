using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class UsersAdapter : BaseAdapter<Users>
	{
		Activity activity;
		int layoutResourceId;
		List<Users> users = new List<Users>();

		public UsersAdapter(Activity activity, int layoutResourceId)
		{
			this.activity = activity;
			this.layoutResourceId = layoutResourceId;
		}

		//Returns the view for a specific item on the list
		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var row = convertView;
			var currentItem = this [position];
			CheckBox checkBox;

			if (row == null) {
				var inflater = activity.LayoutInflater;
				row = inflater.Inflate (layoutResourceId, parent, false);

				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem); // fix this

				checkBox.CheckedChange += async (sender, e) => {
					var cbSender = sender as CheckBox;
					if (cbSender != null && cbSender.Tag is Users.UsersWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
                        if (activity is Activities.UsersActivity)
                            await ((Activities.UsersActivity)activity).CheckUsers((cbSender.Tag as Users.UsersWrapper).Users);
                    }
				};
			} else
				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem); //fix this

		//	checkBox.Text = currentItem.Text;
	    //	checkBox.Checked = false;
	    //	checkBox.Enabled = true;
		//	checkBox.Tag = new ToDoItemWrapper (currentBeacon);

			return row;
		}

		public void Add (Users user)
        {
            users.Add (user);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            users.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Users user)
		{
            users.Remove (user);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return users.Count;
			}
		}

		public override Users this [int position] {
			get {
                return users[position];
			}
		}

		#endregion
	}
}

