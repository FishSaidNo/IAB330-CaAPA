using System;

namespace CaAPA.Data
{
	public interface ITextToSpeech
	{
		void speak(string text, float speed);
	}
}

