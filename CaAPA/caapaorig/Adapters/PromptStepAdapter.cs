using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using caapaorig;
using caapaorig.Items;

namespace caapa.Adapters
{
	public class PromptStepAdapter : BaseAdapter<PromptStep>
	{
		Activity activity;
		int layoutResourceId;
		List<PromptStep> promptsteps = new List<PromptStep>();

		public PromptStepAdapter(Activity activity, int layoutResourceId)
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
					if (cbSender != null && cbSender.Tag is PromptStep.PromptStepWrapper && cbSender.Checked) {
						cbSender.Enabled = false;
                        if (activity is Activities.PromptStepActivity)
                            await ((Activities.PromptStepActivity)activity).CheckPromptStep((cbSender.Tag as PromptStep.PromptStepWrapper).PromptStep);
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

		public void Add (PromptStep promptstep)
		{
            promptsteps.Add (promptstep);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            promptsteps.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (PromptStep promptstep)
		{
            promptsteps.Remove (promptstep);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return promptsteps.Count;
			}
		}

		public override PromptStep this [int position] {
			get {
                return promptsteps[position];
			}
		}

		#endregion
	}
}

