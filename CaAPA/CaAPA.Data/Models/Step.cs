using System;


namespace CaAPA.Data
{
	public class Step
	{
		public string Instructions { set; get; }
		public string imgUri { set; get; }
		public Step(string instructions, string imguri ="")
		{
			Instructions = instructions;
			imgUri = imguri;
		}
	}
}