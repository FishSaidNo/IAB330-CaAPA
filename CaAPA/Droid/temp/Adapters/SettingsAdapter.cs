using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class SettingsAdapter : BaseAdapter<Settings>
	{
		Activity activity;
		int layoutResourceId;
		List<Settings> settings = new List<Settings>();

		public SettingsAdapter(Activity activity, int layoutResourceId)
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
					if (cbSender != null && cbSender.Tag is Settings.SettingsWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
                        if (activity is Activities.SettingsActivity)
                            await ((Activities.SettingsActivity)activity).CheckSettings((cbSender.Tag as Settings.SettingsWrapper).Settings);
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

		public void Add (Settings setting)
        {
            settings.Add (setting);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            settings.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Settings setting)
		{
            settings.Remove (setting);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return settings.Count;
			}
		}

		public override Settings this [int position] {
			get {
                return settings[position];
			}
		}

		#endregion
	}
}

