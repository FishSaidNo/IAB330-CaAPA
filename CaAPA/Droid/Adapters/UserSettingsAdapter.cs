using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class UserSettingsAdapter : BaseAdapter<UserSettings>
	{
		Activity activity;
		int layoutResourceId;
		List<UserSettings> usersettings = new List<UserSettings>();

		public UserSettingsAdapter(Activity activity, int layoutResourceId)
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
					if (cbSender != null && cbSender.Tag is UserSettings.UserSettingsWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
                        if (activity is Activities.UserSettingsActivity)
                            await ((Activities.UserSettingsActivity)activity).CheckUserSettings((cbSender.Tag as UserSettings.UserSettingsWrapper).UserSettings);
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

		public void Add (UserSettings usersetting)
        {
            usersettings.Add (usersetting);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            usersettings.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (UserSettings usersetting)
		{
            usersettings.Remove (usersetting);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return usersettings.Count;
			}
		}

		public override UserSettings this [int position] {
			get {
                return usersettings[position];
			}
		}

		#endregion
	}
}

