using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ItemManager : MonoBehaviour {

	public GameObject apple;
	public GameObject bread;
	public GameObject banana;
	public GameObject donut;
	public GameObject cokeCan;
	public GameObject cokeBottle;
	public GameObject beer;
	public GameObject water;
	public GameObject medKit;
	public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public float spawnTime;
	public Transform[] spawnPoints;
	// Use this for initialization
	void Awake () {
		InvokeRepeating("SpawnItems", 1, spawnTime);
	}

	void Start(){
	}
	// Update is called once per frame
	void Update () {
	}

	void SpawnItems(){
		//Debug.Log ("Item Spawning");
		for(int i=0; i<spawnPoints.Length; i++){
			int r= Random.Range(1,12);
			switch(r){
			case 1:
				Instantiate (apple, spawnPoints [i].position, apple.transform.rotation);
				break;
			case 2:
				Instantiate (banana, spawnPoints [i].position, banana.transform.rotation);
				break;
			case 3:
				Instantiate (donut, spawnPoints [i].position, donut.transform.rotation);
				break;
			case 4:
				Instantiate (bread, spawnPoints [i].position, bread.transform.rotation);
				break;
			case 5:
				Instantiate (cokeCan, spawnPoints [i].position, cokeCan.transform.rotation);
				break;
			case 6:
				Instantiate (cokeBottle, spawnPoints [i].position, cokeBottle.transform.rotation);
				break;
			case 7:
				Instantiate (water, spawnPoints [i].position, water.transform.rotation);
				break;
			case 8:
				Instantiate (beer, spawnPoints [i].position, beer.transform.rotation);
				break;
			case 9:
				Instantiate (medKit, spawnPoints [i].position, medKit.transform.rotation);
				break;
			case 10:
				Instantiate (ammo1, spawnPoints [i].position, ammo1.transform.rotation);
				break;
			case 11:
				Instantiate (ammo2, spawnPoints [i].position, ammo2.transform.rotation);
				break;
			case 12:
				Instantiate (ammo3, spawnPoints [i].position, ammo3.transform.rotation);
				break;
			default:
				break;
			}
		}

	}

	void StopSpawning(){
		CancelInvoke ();
	}
}
