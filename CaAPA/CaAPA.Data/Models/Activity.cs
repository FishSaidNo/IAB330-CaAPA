using System;
using SQLite.Net.Attributes;

namespace CaAPA.Data
{
	//internal elements

	public class Activity
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		[NotNull, MaxLength(128)]
		public string ActivityName { get; set; }
		public string ActivityLocation { get; set; }
		public int NumberOfSteps { get; set; }

		public Step Step = new Step("blah");

		private Step[] _activitySteps;

		private int _currentStep = 0;
		private int _steps = 0;

		Activity()
		{
		}

		public Activity(string activityName = "Default", string activityLocation = "Somewhere")
		{
			ActivityName = activityName;
			ActivityLocation = activityLocation;
			_activitySteps = new Step[25];
		}

		public bool IncrementStep()
		{
			_currentStep++;
			if (_currentStep > _steps)
			{
				this.DecrementStep();
				return false;
			}
			Step.Instructions = _activitySteps[_currentStep].Instructions;
			Step.imgUri = _activitySteps[_currentStep].imgUri;
			return true;
			//reassign step values here
		}

		public bool DecrementStep()
		{
			_currentStep--;
			if (_currentStep < 0)
			{
				this.IncrementStep();
				return false;
			}
			Step.Instructions = _activitySteps[_currentStep].Instructions;
			Step.imgUri = _activitySteps[_currentStep].imgUri;
			return true;
			//reassign step values here
		}
		public void AddStep(string Instructions, System.Uri Imguri = null)
		{
			_activitySteps[_steps] = new Step(Instructions, Imguri);
			_steps++;
		}

	}
}