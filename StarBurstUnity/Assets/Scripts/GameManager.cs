using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RJWard.StarBurst
{
	public class GameManager: RJWard.Core.Singleton.SingletonSceneLifetime<GameManager>
	{
		public GameObject playerPrefab;

		private Player _player;

		void Start( )
		{
			_player = Instantiate( playerPrefab ).GetComponent<Player>( );
			_player.gameObject.name = "Player";

		}

	}
}
