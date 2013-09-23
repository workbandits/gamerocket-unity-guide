using System;
using System.Collections.Generic;

namespace GameRocket
{
	public class Response
	{
		public bool success;
		
		public string error;
		
		internal Dictionary<string, object> json;
		
		public static Response GeneralError(string message)
		{
			return new Response {
				success = false,
				error = message
			};
		}
		
		public string errormessage
		{
			get 
			{
				if (!string.IsNullOrEmpty(error))
					return error;
				
				return "Nothing went wrong!";
			}
		}
		
		public Response ()
		{
		}
	}
}

