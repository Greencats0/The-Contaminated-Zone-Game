using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PostProcessing;
using VRTK;
public class Walker : MonoBehaviour {


	Transform player;
	Transform enemy;
	//float moveSpeed = 1.5f;
	//float rotationSpeed = 4f;
	Animator anim;
	public GameObject game;
	private float health = 30f;
	private bool alerted;
	NavMeshAgent agent;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioClip idle;
	public AudioClip lookAround;
	public AudioClip hit;
	public AudioClip attack;
	public AudioClip footStep;
	public float audioDelay = 40f;
	void Awake(){
		enemy = transform;

	}
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
		alerted = false;
		agent = GetComponent<NavMeshAgent> ();
		game = GameObject.FindWithTag ("GameManager");
		player = GameObject.FindWithTag ("Player").transform;
		//player = game.GetComponentInParent<VRTK_BodyPhysics>().gameObject.GetComponentInChildren<PostProcessingBehaviour>().gameObject.transform;
		//player.position = new Vector3 (player.position.x, game.transform.position.y, player.position.z);
	}

	void TakeDamage(float damage){
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		health -= damage;
		var distance = Vector3.Distance (player.position, enemy.position);
		agent.ResetPath ();
		if(!(state.IsName ("FallB") || state.IsName ("FallL") || state.IsName ("FallR") || state.IsName("Dead"))&& health>0){
			if (distance >= 25.0f) {
				anim.Play ("HitIdle");
				alerted = true;
			} else if (distance < 25.0f && distance >= 20.0f) {
				anim.Play ("HitNear");
				alerted = true;
			} else if (distance < 20.0f) {
				anim.Play ("Hit");
				alerted = true;

			}

		}

		if (health <= 0 && !(state.IsName ("FallB") || state.IsName ("FallL") || state.IsName ("FallR") || state.IsName("Dead"))) {
			health = 0;
			int r = Random.Range (0, 2);
			switch(r){
			case 1:
				anim.Play ("FallB");
				break;
			case 2:
				anim.Play ("FallL");
				break;
			default:
				anim.Play ("FallR");
				break;

			}
		}
		audio1.PlayOneShot (hit);
	}

	void FixedUpdate(){
		if (audioDelay > 0) {
			audioDelay -= 1;
		}
	}
	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance (player.position, enemy.position);
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);

		if(!(state.IsName ("FallB") || state.IsName ("FallL") || state.IsName ("FallR") || state.IsName("HitIdle")|| state.IsName("HitNear") || state.IsName("Hit") || state.IsName("Dead"))){
			if (distance <= 1.0f && state.IsName ("Walk00")) {
				anim.Play ("Attack00");
				audio1.PlayOneShot (attack);
				game.GetComponent<PlayerHealth> ().SendMessage ("TakeDamage", 20.0f);
				game.GetComponent<PlayerHealth> ().SendMessage ("UpdateHealth");
			} else if (distance > 50.0f) {
				alerted = false;
				gameObject.SetActive (false);
			} else if (distance >= 25.0f && distance <=50.0f) {
				alerted = false;
				anim.Play ("Idle");
				if (!audio1.isPlaying) {
					audio1.PlayOneShot (idle);
				}
			}else if (distance < 25.0f && distance >= 20.0f) {
				alerted = false;
				anim.Play ("LookAround");
				if (!audio1.isPlaying) {
					audio1.PlayOneShot (lookAround);
				}
			}else if (distance > 1.0f && distance < 20.0f && !alerted) {
				alerted = true;
				anim.Play ("Alerted");
				if (!audio1.isPlaying) {
					audio1.PlayOneShot (attack);
				}
			}else if (distance > 1.0f && distance < 20.0f && !state.IsName("Alerted") && alerted && health>0 ) {
				//enemy.rotation = Quaternion.Slerp (enemy.rotation, Quaternion.LookRotation (player.position - enemy.position), rotationSpeed * Time.deltaTime); 
				//enemy.position += enemy.forward * moveSpeed * Time.deltaTime;
				agent.SetDestination(player.position);
				anim.Play ("Walk00");
				if (!audio2.isPlaying) {
					audio2.Play ();
				}
				if (audioDelay == 0) {
					audio1.Play ();
					audioDelay = 40;
				}
			}
		}else if(state.IsName("Dead")){
			Destroy (enemy.gameObject);
			int r = Random.Range (1, 20);
			switch (r) {
			case 1:
				game.GetComponent<UpgradeManager>().RecieveUpgradePoint (1);
				break;
			case 2:
				game.GetComponent<UpgradeManager>().RecieveUpgradePoint (1);
				break;
			case 3:
				game.GetComponent<UpgradeManager>().RecieveUpgradePoint (1);
				break;
			case 4:
				game.GetComponent<UpgradeManager>().RecieveUpgradePoint (1);
				break;
			case 5:
				game.GetComponent<UpgradeManager>().RecieveUpgradePoint (2);
				break;
			}
		}
	}
}
