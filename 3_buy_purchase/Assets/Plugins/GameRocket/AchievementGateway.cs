using System;
using System.Collections;

namespace GameRocket
{
	public class AchievementGateway
	{
		public void Find(string player, string id, Action<Achievement, Response> callback)
		{
			GameRocketGateway.API.StartCoroutine(DoFind(player, id, callback));
		}
		
		internal IEnumerator DoFind(string player, string id, Action<Achievement, Response> callback)
		{
			var www = Request.Get("/players/" + player + "/achievements/" + id);
			yield return www;
			
			var response = Request.Process(www);
			var data = response.success ? response.json : null;
			
			Achievement achievement = new Achievement();
			
			if (response.success)
			{
				var achievementarray = data["achievement"];
				achievement = (Achievement) Activator.CreateInstance(typeof(Achievement), new object[] { achievementarray });
			}
			
			callback(achievement, response);
		}
	}
}

