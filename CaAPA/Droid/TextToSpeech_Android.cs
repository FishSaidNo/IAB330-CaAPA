using System;
using Android.Speech.Tts;
using CaAPA.Droid;
using CaAPA.Data;
using Xamarin.Forms;
using System.Collections.Generic;

[assembly: Dependency(typeof(TextToSpeech_Android))]

namespace CaAPA.Droid
{
	public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string tosay;
		float speakSpeed;

		public TextToSpeech_Android () {}

		public void speak(string text, float speed)
		{
			var context = Forms.Context;
			tosay = text;
			speakSpeed = speed;

			if (speaker == null) {
				speaker = new TextToSpeech (context, this);

			} else {
				var d = new Dictionary<string, string> ();

				speaker.SetSpeechRate (speakSpeed);
				speaker.Speak (tosay, QueueMode.Flush, d);
			}
		}
		#region IOnInitListener Implementation
		public void OnInit(OperationResult status){
			if (status.Equals (OperationResult.Success)) {
				var p = new Dictionary<string,string> ();

				speaker.SetSpeechRate (speakSpeed);
				speaker.Speak (tosay, QueueMode.Flush, p);	
			}
		}
		#endregion

	}
}

