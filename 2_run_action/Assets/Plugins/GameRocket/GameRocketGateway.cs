using UnityEngine;
using System;

namespace GameRocket
{
	public class GameRocketGateway : MonoBehaviour {
		
		private GameGateway _game;
		
		private PlayerGateway _player;
		
		private ActionGateway _action;
		
		private PurchaseGateway _purchase;
		
		private AchievementGateway _achievement;
		
		private string _apikey;
		
		private string _secretkey;
		
		private static GameRocketGateway _instance = null;
		
		public static void Initialize(Environment environment, string apikey, string secretkey)
		{
			if (_instance != null) 
				return;
			
			var go = new GameObject("gamerocket");
			GameObject.DontDestroyOnLoad(go);
			
			_instance = go.AddComponent("GameRocketGateway") as GameRocketGateway;
			_instance._apikey = apikey;
			_instance._secretkey = secretkey;
			_instance._game = new GameGateway();
			_instance._player = new PlayerGateway();
			_instance._action = new ActionGateway();
			_instance._purchase = new PurchaseGateway();
			_instance._achievement = new AchievementGateway();
			
			Request.Initialize(environment, secretkey);
		}
		
		internal static GameRocketGateway API
		{
			get { return _instance; }
		}
		
		internal static string APIKEY
		{
			get { return _instance._apikey; }
		}
		
		internal static string SECRETKEY
		{
			get { return _instance._secretkey; }
		}
		
		public static GameGateway Game
		{
			get { return _instance._game; }
		}
		
		public static PlayerGateway Player
		{
			get { return _instance._player; }
		}
		
		public static ActionGateway Action
		{
			get { return _instance._action; }
		}
		
		public static PurchaseGateway Purchase
		{
			get { return _instance._purchase; }
		}
		
		public static AchievementGateway Achievement
		{
			get { return _instance._achievement; }
		}
	}
}