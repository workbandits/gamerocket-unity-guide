using System;
using System.Collections;

namespace GameRocket
{
	public class PlayerGateway
	{
		public void Find(string id, Action<Player, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoFind(id, callback));
		}
		
		internal IEnumerator DoFind(string id, Action<Player, Response> callback)
		{
			var www = Request.Get("/players/" + id);
			yield return www;
			
			var response = Request.Process(www);
			var data = response.success ? response.json : null;
			
			Player player = new Player();
			
			if (response.success)
			{
				var playerarray = data["player"];
				player = (Player) Activator.CreateInstance(typeof(Player), new object[] { playerarray });
			}
			
			callback(player, response);
		}
		
		public void Create(PlayerOptions options, Action<Player, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoCreate(options, callback));
		}
		
		internal IEnumerator DoCreate(PlayerOptions options, Action<Player, Response> callback)
		{
			var www = Request.Post("/games/" + GameRocketGateway.APIKEY + "/players", options);
			yield return www;
			
			var response = Request.Process(www);
			var data = response.success ? response.json : null;
			
			Player player = new Player();
			
			if (response.success)
			{
				var playerarray = data["player"];
				player = (Player) Activator.CreateInstance(typeof(Player), new object[] { playerarray });
			}
			
			callback(player, response);
		}
		
		public void Update(String id, PlayerOptions options, Action<Player, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoUpdate(id, options, callback));
		}
		
		internal IEnumerator DoUpdate(String id, PlayerOptions options, Action<Player, Response> callback)
		{
			var www = Request.Post("/players/" + id + "/update", options);
			yield return www;
			
			var response = Request.Process (www);
			var data = response.success ? response.json : null;
			
			Player player = new Player();
			
			if (response.success)
			{
				var playerarray = data["player"];
				player = (Player) Activator.CreateInstance(typeof(Player), new object[] { playerarray });
			}
			
			callback(player, response);
 		}
		
		public void Delete(String id, Action<Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoDelete (id, callback));
		}
		
		internal IEnumerator DoDelete(String id, Action<Response> callback)
		{
			var www = Request.Post("/players/" + id + "/delete");
			yield return www;
			
			var response = Request.Process (www);
			callback(response);
		}
	}
}

