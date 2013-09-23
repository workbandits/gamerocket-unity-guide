using System;
using System.Collections;
using System.Collections.Generic;

namespace GameRocket
{
	public class Achievement : GRDictionary
	{
		public Achievement() : base() {}
		
		public Achievement(IDictionary data)
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
		
		public int Progression
		{
			get { return GetInt("progression"); }
			set { SetProperty("progression", value); }
		}
		
		public bool Unlocked
		{
			get { return GetBool ("unlocked"); }
			set { SetProperty ("unlocked", value); }
		}
		
		public long UnlockedDate
		{
			get { return GetLong ("unlockedDate"); }
			set { SetProperty("unlockedDate", value); }
		}
		
		public DateTime UnlockedDateTime
		{
			get { 
				#pragma warning disable 0472
				#pragma warning disable 0162
				if (UnlockedDate == null) { return new DateTime(); } else { return new DateTime().AddSeconds(UnlockedDate / 1000); } 
				#pragma warning disable 0162
				#pragma warning disable 0472
			}
		}
		
		public Dictionary<string, object> DynProp
		{
			get { return ContainsKey ("dynProp") ? (Dictionary<string,object>)this["dynProp"] : new Dictionary<string,object>(); }
			set { SetProperty ("dynProp", value); }
		}
		
		public Dictionary<string, object> Template
		{
			get { return ContainsKey ("template") ? (Dictionary<string,object>)this["template"] : new Dictionary<string,object>(); }
			set { SetProperty ("template", value); }
		}
	}
}

