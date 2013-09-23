using UnityEngine;
using System.Collections;
using GameRocket;

public class CreatePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameRocketGateway.Initialize(Environment.PRODUCTION, "your_apikey", "your_secretkey");
		
		var playerOptions = new PlayerOptions {
            Name = "ytreza",
            Locale = "en_US" // Example: en_US or fr_FR
        };

        GameRocketGateway.Player.Create(playerOptions, (player, response) => {
            if (response.success)
            {
                // Save the player.Id to your database for next calls.
                Debug.Log (player.Id);
            }
            else
            {
                Debug.Log(response.errormessage);
            }
        });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
