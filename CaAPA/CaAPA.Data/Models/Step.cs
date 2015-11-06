using System;


namespace CaAPA.Data
{
	public class Step
	{
		public string Instructions { set; get; }
		public System.Uri imgUri { set; get; }
		public Step(string instructions, System.Uri imguri = null)
		{
			Instructions = instructions;
			imgUri = imguri;
		}
	}
}