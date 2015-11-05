using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class GuiSettingsAdapter : BaseAdapter<GuiSettings>
	{
		Activity activity;
		int layoutResourceId;
		List<GuiSettings> guisettings = new List<GuiSettings>();

		public GuiSettingsAdapter(Activity activity, int layoutResourceId)
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
						if (activity is Activities.GuiSettingsActivity)
							await ((Activities.GuiSettingsActivity)activity).CheckGuiSettings ((cbSender.Tag as GuiSettings.GuiSettingsWrapper).GuiSettings);
					}
				};
			} else
				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem); //change to fit

		//	checkBox.Text = currentItem.Text;
	    //	checkBox.Checked = false;
	    //	checkBox.Enabled = true;
		//	checkBox.Tag = new ToDoItemWrapper (currentBeacon);

			return row;
		}

		public void Add (GuiSettings guisetting)
		{
            guisettings.Add (guisetting);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            guisettings.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (GuiSettings guisetting)
		{
            guisettings.Remove (guisetting);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return guisettings.Count;
			}
		}

		public override GuiSettings this [int position] {
			get {
                return guisettings[position];
			}
		}

		#endregion
	}
}

