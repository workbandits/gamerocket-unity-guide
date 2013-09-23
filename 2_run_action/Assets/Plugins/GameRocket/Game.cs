using System;
using System.Collections;
using System.Collections.Generic;

namespace GameRocket
{
	public class Game : GRDictionary
	{
		public Game() : base() {}
		
		public Game(IDictionary data)
		{
			foreach (string x in data.Keys)
			{
				this[x] = data[x];
			}
		}
		
		public string id
		{
			get { return GetString ("id"); }
			set { SetProperty("id", value); }
		}
		
		public string name
		{
			get { return GetString ("name"); }
			set { SetProperty ("name", value); }
		}
		
		public string status
		{
			get { return GetString ("status"); }
			set { SetProperty ("name", Values); }
		}
		
		public Dictionary<string, object> dynProp
		{
			get { return ContainsKey ("dynProp") ? (Dictionary<string,object>)this["dynProp"] : new Dictionary<string,object>();	}
			set { SetProperty ("dynProp", value); }
		}
	}
}

