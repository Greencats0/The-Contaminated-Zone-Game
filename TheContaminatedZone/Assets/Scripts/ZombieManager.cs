using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ZombieManager : MonoBehaviour {

	//GameObject[] walkers;
	public GameObject walker;
	public GameObject runner;
	public float spawnTime;
	public Transform[] spawnPoints;
	// Use this for initialization
	void Awake () {
		//walkers = GameObject.FindGameObjectsWithTag ("Walker");
		InvokeRepeating("Spawn", 1, spawnTime);

	}

	void Start(){
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(){
		//Debug.Log ("Spawn is being called");
		for(int i=0; i<spawnPoints.Length; i++){
			int r= Random.Range(1,5);
			switch(r){
			case 1:
				Instantiate (walker, spawnPoints [i].position, spawnPoints[i].rotation);
				break;
			case 2:
				Instantiate (walker, spawnPoints [i].position, spawnPoints [i].rotation);
				break;
			case 3:
				Instantiate (walker, spawnPoints [i].position, spawnPoints [i].rotation);
				break;
			case 4:
				Instantiate (runner, spawnPoints [i].position, spawnPoints [i].rotation);
				break;
			case 5:
				Instantiate (runner, spawnPoints [i].position, spawnPoints [i].rotation);
				break;
			default:
				break;
			}
		}

	}

	void StopSpawning(){
		CancelInvoke ();
	}
	//Sets movement based on enemy
	//void SetMovement(GameObject enemy){
		//if (enemy.CompareTag ("Walker")) {
			//enemy.AddComponent<Walker>();
		//}
	//}
}

