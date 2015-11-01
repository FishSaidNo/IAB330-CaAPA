using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class BeaconAdapter : BaseAdapter<Beacon>
	{
		Activity activity;
		int layoutResourceId;
		List<Beacon> beacons = new List<Beacon>();

		public BeaconAdapter(Activity activity, int layoutResourceId)
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

				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem);

				checkBox.CheckedChange += async (sender, e) => {
					var cbSender = sender as CheckBox;
					if (cbSender != null && cbSender.Tag is BeaconWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
						if (activity is Activities.BeaconActivity)
							await ((Activities.BeaconActivity)activity).CheckBeacon((cbSender.Tag as BeaconWrapper).Beacon);
					}
				};
			} else
				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem);

		//	checkBox.Text = currentItem.Text;
	    //	checkBox.Checked = false;
	    //	checkBox.Enabled = true;
		//	checkBox.Tag = new ToDoItemWrapper (currentBeacon);

			return row;
		}

		public void Add (Beacon beacon)
		{
            beacons.Add (beacon);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            beacons.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Beacon beacon)
		{
            beacons.Remove (beacon);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return beacons.Count;
			}
		}

		public override Beacon this [int position] {
			get {
                return beacons[position];
			}
		}

		#endregion
	}
}

