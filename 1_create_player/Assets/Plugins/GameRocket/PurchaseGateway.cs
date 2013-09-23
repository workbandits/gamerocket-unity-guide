using System;
using System.Collections;
using System.Collections.Generic;

namespace GameRocket
{
	public class PurchaseGateway
	{
		public void Find(string id, Action<Purchase, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoFind(id, callback));
		}
		
		internal IEnumerator DoFind(string id, Action<Purchase, Response> callback)
		{
			var www = Request.Get("/games/" + GameRocketGateway.APIKEY + "/purchases/" + id);
			yield return www;
			
			var response = Request.Process(www);
			var data = response.success ? response.json : null;
			
			Purchase purchase = new Purchase();
			
			if (response.success)
			{
				var purchasearray = data["purchase"];
				purchase = (Purchase) Activator.CreateInstance(typeof(Purchase), new object[] { purchasearray });
			}
			
			callback(purchase, response);
		}
		
		public void Buy(string id, Dictionary<string, object> parameters, Action<Dictionary<string, object>, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoBuy(id, parameters, callback));
		}
		
		internal IEnumerator DoBuy(string id, Dictionary<string, object> parameters, Action<Dictionary<string, object>, Response> callback)
		{
			var www = Request.Post("/games/" + GameRocketGateway.APIKEY + "/purchases/" + id + "/buy", parameters);
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

