using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameRocket;

public class RunAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameRocketGateway.Initialize (Environment.PRODUCTION, "your_apikey", "your_secretkey");
		
		var parameters = new Dictionary<string, object> {
            {"player", "use_player_id"},
            {"name", "John"}
        };

        GameRocketGateway.Action.Run ("hello-world", parameters, (result, response) => {
            if (response.success)
            {
                Dictionary<string, object> data = (Dictionary<string, object>) result["data"];
                Debug.Log (data["hello"]);
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
