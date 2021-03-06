using System;
using System.Collections;
using System.Collections.Generic;

namespace GameRocket
{
	public class Action : GRDictionary
	{
		public Action() : base() {}
		
		public Action(IDictionary data)
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
		
		public string Ref
		{
			get { return GetString ("ref"); }
			set { SetProperty ("ref", value); }
		}
		
		public string Name
		{
			get { return GetString ("name"); }
			set { SetProperty ("name", value); }
		}
		
		public Dictionary<string, object> DynProp
		{
			get { return ContainsKey ("dynProp") ? (Dictionary<string,object>)this["dynProp"] : new Dictionary<string,object>(); }
			set { SetProperty ("dynProp", value); }
		}
	}
}

