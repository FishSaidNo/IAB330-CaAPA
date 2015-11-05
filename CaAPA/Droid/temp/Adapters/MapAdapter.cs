using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class MapAdapter : BaseAdapter<Map>
	{
		Activity activity;
		int layoutResourceId;
		List<Map> maps= new List<Map>();

		public MapAdapter(Activity activity, int layoutResourceId)
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
					if (cbSender != null && cbSender.Tag is Map.MapWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
						if (activity is Activities.MapActivity)
							await ((Activities.MapActivity)activity).CheckMap((cbSender.Tag as Map.MapWrapper).Map);
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

		public void Add (Map map)
		{
            maps.Add (map);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            maps.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Map map)
		{
            maps.Remove (map);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return maps.Count;
			}
		}

		public override Map this [int position] {
			get {
                return maps[position];
			}
		}

		#endregion
	}
}

