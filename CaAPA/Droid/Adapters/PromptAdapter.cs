using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android;

namespace caapa { 
	public class PromptAdapter : BaseAdapter<Prompt>
	{
		Activity activity;
		int layoutResourceId;
        List<Prompt> prompts = new List<Prompt>();

		public PromptAdapter(Activity activity, int layoutResourceId)
		{
			this.activity = activity;
			this.layoutResourceId = layoutResourceId;
		}

		//Returns the view for a specific item on the list
		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
            /*
            var row = convertView;
			var currentItem = this [position];
			CheckBox checkBox;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);


                checkBox = row.FindViewById<CheckBox>(Resource.Id.KeyboardView); // fix this
                                                                                
                   /*                                                              checkBox.CheckedChange += async (sender, e) => {
                                                                                     var cbSender = sender as CheckBox;
                                                                                     if (cbSender != null && cbSender.Tag is Prompt.PromptWrapper && cbSender.Checked) {
                                                                                         cbSender.Enabled = false;
                                                                                         if (activity is MainActivity)
                                                                                            // await ((MainActivity)activity).CheckPrompt((cbSender.Tag as Prompt.PromptWrapper).Prompt);
                                                                                     }
                                                                                 };
                     */
            //}
            //else
            // {
            //checkBox = row.FindViewById <CheckBox> (Resource.Id.checkToDoItem); //fix this

            //	checkBox.Text = currentItem.Text;
            //	checkBox.Checked = false;
            //	checkBox.Enabled = true;
            //	checkBox.Tag = new ToDoItemWrapper (currentBeacon);



            //return row;
            return null;
           // }
		}

		public void Add (Prompt prompt)
		{
            prompts.Add (prompt);
			NotifyDataSetChanged ();
		}

		public void Clear ()
		{
            prompts.Clear ();
			NotifyDataSetChanged ();
		}

		public void Remove (Prompt prompt)
		{
            prompts.Remove (prompt);
			NotifyDataSetChanged ();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return prompts.Count;
			}
		}

		public override Prompt this [int position] {
			get {
                return prompts[position];
			}
		}

		#endregion
	}
}

