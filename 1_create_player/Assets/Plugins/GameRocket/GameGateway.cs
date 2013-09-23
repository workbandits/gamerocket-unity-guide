using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRocket
{
	public class GameGateway
	{
		public void Find(string id, Action<Game, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoFind(id, callback));
		}
		
		internal IEnumerator DoFind(string id, Action<Game, Response> callback)
		{
			var www = Request.Get("/games/" + id);
			yield return www;
			
			var response = Request.Process(www);
			var data = response.success ? response.json : null;
			
			Game game = new Game();
			
			if (response.success)
			{
				var gamearray = data["game"];
				game = (Game) Activator.CreateInstance(typeof(Game), new object[] { gamearray });
			}
			
			callback(game, response);
		}
	}
}

