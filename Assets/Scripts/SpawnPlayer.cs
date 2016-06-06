using UnityEngine;
using System.Collections;
using System;

public class SpawnPlayer : MonoBehaviour
{


	public bool respawn = false;
	private GameObject[] playerSpawnPoints;
	private GameObject player;
	// Use this for initialization
	void Start ()
	{
		playerSpawnPoints = GameObject.FindGameObjectsWithTag ("PlayerSpawn");
		player = GameObject.FindGameObjectWithTag ("Player");
		ReSpawnPlayer ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (respawn) {
			ReSpawnPlayer ();
			respawn = false;
		}
	}

	private void ReSpawnPlayer ()
	{
		if (player)
			Destroy (player);
		
	
		InstantiatePlayer ();

	}

	private void InstantiatePlayer ()
	{
		int point = UnityEngine.Random.Range (0, playerSpawnPoints.Length);
		print (point);
		player = Instantiate (Resources.Load ("Prefabs/Player"))as GameObject;
		player.transform.position = playerSpawnPoints [point].transform.position;
		player.transform.rotation = playerSpawnPoints [point].transform.rotation;
		player.name = "Player";

	}
}
