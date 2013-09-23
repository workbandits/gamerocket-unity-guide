using System;

namespace GameRocket
{
	public class PlayerOptions : GRDictionary
	{
		public String name
		{
			get { return GetString ("name"); }
			set { SetProperty ("name", value); }
		}
		
		public string locale
		{
			get { return GetString("locale"); }
			set { SetProperty ("locale", value); }
		}
		
		public string emailHash
		{
			get { return GetString("emailHash"); }
			set { SetProperty ("emailHash", value); }
		}
	}
}

