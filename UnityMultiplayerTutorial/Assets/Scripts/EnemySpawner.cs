using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {


	public GameObject enemyPref;
	public int numOfEnemies;


	public override void OnStartServer()
	{
		for (int i = 0; i < numOfEnemies; i++)
		{
			var spawnPos = new Vector3 (Random.Range (-8.0f, 8.0f), 0.0f, Random.Range (-8.0f, 8.0f));
			var spawnRot = Quaternion.Euler (0.0f, Random.Range (0.0f, 180.0f), 0.0f);
			var enemy = (GameObject)Instantiate (enemyPref, spawnPos, spawnRot);
			NetworkServer.Spawn (enemy);
		}
	}

}
