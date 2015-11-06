using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapa.Adapters;

namespace caapa.Adapters
{
	public class ActivitiesAdapter : BaseAdapter<Activities>
	{
		Activity activitie;
		int layoutResourceId;
		List<Activities> activities = new List<Activities>();

		public ActivitiesAdapter(Activity activitie, int layoutResourceId)
		{
            this.activitie = activitie;
			this.layoutResourceId = layoutResourceId;
		}

		//Returns the view for a specific item on the list
		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var row = convertView;
			var currentItem = this [position];
			CheckBox checkBox;

			if (row == null) {
				var inflater = activitie.LayoutInflater;
				row = inflater.Inflate (layoutResourceId, parent, false);

                /*
				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem); // fix this

				checkBox.CheckedChange += async (sender, e) => {
					var cbSender = sender as CheckBox;
					if (cbSender != null && cbSender.Tag is Prompt.PromptWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
                        if (activity is SynchActivity)
                            await ((SynchActivity)activity).CheckPrompt((cbSender.Tag as Prompt.PromptWrapper).Prompt);
                    }
				};
                */
			} else
				checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem); //fix this

		//	checkBox.Text = currentItem.Text;
	    //	checkBox.Checked = false;
	    //	checkBox.Enabled = true;
		//	checkBox.Tag = new ToDoItemWrapper (currentBeacon);

			return row;
		}

		public void Add (Activities activitie)
		{
            activities.Add (activitie);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            activities.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Activities activitie)
		{
            activities.Remove (activitie);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return activities.Count;
			}
		}

		public override Activities this [int position] {
			get {
                return activities[position];
			}
		}

		#endregion
	}
}

