using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameRocket
{
	public class ActionGateway
	{
		public void Find(string id, Action<Action, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoFind(id, callback));
		}
		
		internal IEnumerator DoFind(string id, Action<Action, Response> callback)
		{
			var www = Request.Get("/games/" + GameRocketGateway.APIKEY + "/actions/" + id);
			yield return www;
			
			var response = Request.Process(www);
			var data = response.success ? response.json : null;
			
			Action action = new Action();
			
			if (response.success)
			{
				var actionarray = data["action"];
				action = (Action) Activator.CreateInstance(typeof(Action), new object[] { actionarray });
			}
			
			callback(action, response);
		}
		
		public void Run(string id, Dictionary<string, object> parameters, Action<Dictionary<string, object>, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoRun(id, parameters, callback));
		}
		
		internal IEnumerator DoRun(string id, Dictionary<string, object> parameters, Action<Dictionary<string, object>, Response> callback)
		{
			var www = Request.Post("/games/" + GameRocketGateway.APIKEY + "/actions/" + id + "/run", parameters);
			yield return www;
			
			var response = Request.Process (www);
			var data = response.success ? response.json : null;
			
			GRDictionary results = new GRDictionary();
			if (response.success)
			{
				var resultarray = data;
				results = (GRDictionary) Activator.CreateInstance(typeof(GRDictionary), new object[] {resultarray});
			}
			
			callback(results, response);
		}
	}
}

