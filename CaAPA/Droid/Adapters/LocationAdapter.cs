using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class LocationAdapter : BaseAdapter<Location>
	{
		Activity activity;
		int layoutResourceId;
		List<Location> locations = new List<Location>();

		public LocationAdapter(Activity activity, int layoutResourceId)
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
					if (cbSender != null && cbSender.Tag is Location.LocationWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
						if (activity is Activities.LocationActivity)
							await ((Activities.LocationActivity)activity).CheckLocation((cbSender.Tag as Location.LocationWrapper).Location);
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

		public void Add (Location location)
		{
            locations.Add (location);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            locations.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Location location)
		{
            locations.Remove (location);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return locations.Count;
			}
		}

		public override Location this [int position] {
			get {
                return locations[position];
			}
		}

		#endregion
	}
}

