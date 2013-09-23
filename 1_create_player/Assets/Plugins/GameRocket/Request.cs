using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameRocket
{
	internal class Request
	{
		public static Dictionary<String, Response> Requests = new Dictionary<String, Response>();
		
		private static Environment _environment;
		
		private static string _secretkey;
		
		public static void Initialize(Environment environment, string secretkey)
		{
			_environment = environment;
			_secretkey = secretkey;
		}
		
		public static WWW Get(string url) 
		{
			return new WWW(_environment.GatewayURL + url);
		}
		
		public static WWW Post(string url, Dictionary<string, object> postdata = null)
		{
			if (postdata == null)
			{
				postdata = new Dictionary<string, object>();
			}
			
			postdata.Add ("signature", Crypto.Sign("POST", _environment.GatewayURL + url, postdata, _secretkey));
			
			var form = new WWWForm();
			foreach (KeyValuePair<string, object> entry in postdata)
			{
				form.AddField(entry.Key, (string) entry.Value);
			}
			
			return new WWW(_environment.GatewayURL + url, form);
		}
		
		public static Response Process(WWW www)
		{
			if (www.error != null)
				return Response.GeneralError(www.error);
			
			if (string.IsNullOrEmpty(www.text))
				return Response.GeneralError("No response from server.");
			
			var results = (Dictionary<string, object>) JSON.JsonDecode(www.text);
			
			if (results.ContainsKey("error"))
				return Response.GeneralError((string) results["error_description"]);
			
			var response = new Response();
			response.success = !results.ContainsKey("error");
			if (results.ContainsKey("error_description"))
			{
				response.error = (string) results["error_description"];
			}
			response.json = results;
			
			return response;
		}
	}
}

