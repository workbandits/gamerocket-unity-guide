using System;
using System.Collections;
using System.Collections.Generic;

namespace GameRocket
{
	public class Player : GRDictionary
	{
		public Player() : base() {}
		
		public Player(IDictionary data)
		{
			foreach (string x in data.Keys)
			{
				this[x] = data[x];
			}
		}
		
		public string Id
		{
			get { return GetString ("id"); }
			set { SetProperty("id", value); }
		}
		
		public string Name
		{
			get { return GetString ("name"); }
			set { SetProperty ("name", value); }
		}
		
		public string EmailHash
		{
			get { return GetString ("emailHash"); }
			set { SetProperty ("emailHash", value); }
		}
		
		public int TotalPointsAchievement
		{
			get { return GetInt("totalPointsAchievement"); }
			set { SetProperty ("totalPointsAchievement", value); }
		}
		
		public string Locale
		{
			get { return GetString("locale"); }
			set { SetProperty("locale", value); }
		}
		
		public Dictionary<string, object> DynProp
		{
			get { return ContainsKey ("dynProp") ? (Dictionary<string,object>)this["dynProp"] : new Dictionary<string,object>();	}
			set { SetProperty ("dynProp", value); }
		}
	}
}

