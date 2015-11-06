using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapa;
using CaAPA.Droid;

namespace caapa { 
	public class ActivityAdapter : BaseAdapter<CaAPA.Data.Activities>
	{
		CaAPA.Data.Activities activity;
		int layoutResourceId;
		List<CaAPA.Data.Activities> activities = new List<CaAPA.Data.Activities>();

		public ActivityAdapter(CaAPA.Data.Activities activity, int layoutResourceId)
		{
			this.activity = activity;
			this.layoutResourceId = layoutResourceId;
		}

		//Returns the view for a specific item on the list
		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
//			var row = convertView;
//			var currentItem = this [position];
//			CheckBox checkBox;
//
//			if (row == null) {
//				var inflater = activity.LayoutInflater;
//				row = inflater.Inflate (layoutResourceId, parent, false);
///*
//                checkBox = row.FindViewById<CheckBox>(Resource.Id.beaconId); // fix this
//
//                checkBox.CheckedChange += async (sender, e) => {
//					var cbSender = sender as CheckBox;
//					if (cbSender != null && cbSender.Tag is Prompt.PromptWrapper && cbSender.Checked) {
//						cbSender.Enabled = false;
//                        if (activitie is MainActivity)
//                            //await ((MainActivity)activitie).CheckBeacon((cbSender.Tag as Activities.ActivitiesWrapper).Activities);
//                    }
//				};
//                */
//                
//			} else
//				checkBox = row.FindViewById <CheckBox> (Resource.Id.beaconId); //fix this

		//	checkBox.Text = currentItem.Text;
	    //	checkBox.Checked = false;
	    //	checkBox.Enabled = true;
		//	checkBox.Tag = new ToDoItemWrapper (currentBeacon);

			return null;
		}

		public void Add (CaAPA.Data.Activities activity)
		{
			activities.Add (activity);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            activities.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (CaAPA.Data.Activities activity)
		{
			activities.Remove (activity);
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

		public override CaAPA.Data.Activities this [int position] {
			get {
                return activities[position];
			}
		}

		#endregion
	}
}

