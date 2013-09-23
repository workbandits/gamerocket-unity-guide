using UnityEngine;
using System.Collections;
using GameRocket;

public class BuyPurchase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameRocketGateway.Initialize (Environment.PRODUCTION, "your_apikey", "your_secretkey");
		
		var parameters = new Dictionary<string, object> {
		    {"player", "use_player_id"}
		};
		
		GameRocketGateway.Purchase.Buy ("unlock-content", parameters, (result, response) => {
		    if (response.success)
		    {
		        Dictionary<string, object> data = (Dictionary<string, object>) result["data"];
		        Debug.Log (data["message"]);
		    }
		    else
		    {
		        Debug.Log (response.errormessage);
		    }
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
