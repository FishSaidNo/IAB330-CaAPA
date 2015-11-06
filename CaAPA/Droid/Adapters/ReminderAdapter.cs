using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class ReminderAdapter : BaseAdapter<Reminder>
	{
		Activity activity;
		int layoutResourceId;
		List<Reminder> reminders = new List<Reminder>();

		public ReminderAdapter(Activity activity, int layoutResourceId)
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
					if (cbSender != null && cbSender.Tag is Reminder.ReminderWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
                        if (activity is Activities.ReminderActivity)
                            await ((Activities.ReminderActivity)activity).CheckReminder((cbSender.Tag as Reminder.ReminderWrapper).Reminder);
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

		public void Add (Reminder reminder)
        {
            reminders.Add (reminder);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            reminders.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Reminder reminder)
		{
            reminders.Remove (reminder);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return reminders.Count;
			}
		}

		public override Reminder this [int position] {
			get {
                return reminders[position];
			}
		}

		#endregion
	}
}

