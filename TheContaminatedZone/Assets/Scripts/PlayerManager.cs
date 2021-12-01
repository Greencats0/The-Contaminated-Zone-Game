using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PostProcessing;
using VRTK;
public class PlayerManager : MonoBehaviour {
	Transform player;
	public GameObject playArea;
	Transform play;
	Transform area;
	public bool playerMoving;
	public GameObject[] walkers;
	public GameObject[] runners;
	public AudioSource audio1;
	public float audioDelay = 40.0f;
	void Awake(){
		play = transform;
		area = transform;
	}
	// Use this for initialization
	void Start () {
		playerMoving = false;
		walkers = GameObject.FindGameObjectsWithTag ("Walker");
		runners = GameObject.FindGameObjectsWithTag ("Runner");
		player = GameObject.FindWithTag ("Player").transform;
		play.position =playArea.GetComponentInChildren<PostProcessingBehaviour>().gameObject.transform.position;
		//play.position = new Vector3 (play.position.x, play.transform.position.y, play.position.z);
	}
		
	void Update(){
		for (int i = 0; i < walkers.Length; i++) {
			var distance = Vector3.Distance (player.position, walkers[i].transform.position);
			if (distance > 50.0f) {
				walkers[i].SetActive (false);
			} else if (distance >= 25.0f && distance <=50.0f) {
				walkers[i].SetActive (true);
			}
		}
		for (int i = 0; i < runners.Length; i++) {
			var distance = Vector3.Distance (player.position, runners[i].transform.position);
			if (distance > 50.0f) {
				runners[i].SetActive (false);
			} else if (distance >= 25.0f && distance <=50.0f) {
				runners[i].SetActive (true);
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		var lastPos = area.position;
		play.position =playArea.GetComponentInChildren<PostProcessingBehaviour>().gameObject.transform.position;

		if (audioDelay > 0) {
			audioDelay -= 1;
		}
		player.position =play.position;
		area.position = playArea.transform.position;
		play.position = new Vector3 (play.position.x, playArea.transform.position.y, play.position.z);
		//play.position = playArea.GetComponentInChildren<PostProcessingBehaviour>().gameObject.transform.position;
		//play.position = new Vector3 (play.position.x, play.transform.position.y, play.position.z);

		player.position = new Vector3 (play.position.x, play.transform.position.y, play.position.z);
		//play.position = player.position;
		if (area.position != lastPos) {
			playerMoving = true;
			if (!audio1.isPlaying && audioDelay == 0) {
				audio1.Play ();
				audioDelay = 40f;
			}
		} else {
			playerMoving = false;
			audio1.Stop ();
		}
	}
}
