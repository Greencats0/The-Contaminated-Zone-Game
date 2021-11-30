using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class Item : MonoBehaviour {

	Transform player;
	Transform item;

	public GameObject controllerLeft;
	public GameObject controllerRight;
	public GameObject game;
	public bool itemInRange;
	private float pickUpDelay=20f;
	public float popUpTime = 250f;
	public bool tryToPickUp = false;
	// Use this for initialization
	void Awake(){
		controllerLeft = GameObject.FindGameObjectWithTag ("LeftController");
		controllerRight = GameObject.FindGameObjectWithTag ("RightController");
		game = GameObject.FindGameObjectWithTag ("GameManager");
		player = GameObject.FindWithTag ("Player").transform;
		item = transform;
	}
	void Start () {
		controllerLeft = GameObject.FindGameObjectWithTag ("LeftController");
		controllerRight = GameObject.FindGameObjectWithTag ("RightController");
	}

	void FixedUpdate(){
		if (pickUpDelay > 0) {
			pickUpDelay -= 1;
		}
		if (popUpTime > 0 && game.GetComponent<UpgradeManager> ().popUp.activeInHierarchy) {
			popUpTime -= 1;
		}
		else if (popUpTime == 0 &&game.GetComponent<UpgradeManager> (). popUp.activeInHierarchy && tryToPickUp) {
			tryToPickUp = false;
			popUpTime = 250f;
		}
	}
	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance (player.position, item.position);
		var controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
		//var controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
		if (PreferenceManager.shootingHand == 0) {
			controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
		} else if (PreferenceManager.shootingHand == 1) {
			controllerEvents = controllerRight.GetComponent<VRTK_ControllerEvents> ();
		}
		if (distance <= 1.0f && !tryToPickUp) {
			gameObject.GetComponentInChildren<Renderer> ().material.shader = Shader.Find ("GUI/Text Shader");
			itemInRange = true;
			game.GetComponent<UpgradeManager> ().keepActive = true;
			game.GetComponent<UpgradeManager>().popUp.GetComponentInChildren<Text> ().text = "CLICK MOVEMENT CONTROLLERS TRIGGER TO PICKUP";
			game.GetComponent<UpgradeManager> ().popUp.SetActive (true);
		} else if(!tryToPickUp && !game.GetComponent<UpgradeManager> ().isUpgrade){
			gameObject.GetComponentInChildren<Renderer>().material.shader= Shader.Find("Standard");
			itemInRange = false;
			game.GetComponent<UpgradeManager> ().keepActive = false;
			game.GetComponent<UpgradeManager> ().popUpTime = 0;
		}

		if ((Input.GetKeyDown ("e") || controllerEvents.IsButtonPressed (VRTK_ControllerEvents.ButtonAlias.TriggerClick)) && pickUpDelay == 0 && distance <= 1.0f) {
			if(!(gameObject.tag.Equals(".40 S&W") || gameObject.tag.Equals(".45 ACP") || gameObject.tag.Equals("FN 5.7x28mm")) && !game.GetComponent<InventoryManager>().inventoryFull){
				game.GetComponent<InventoryManager> ().addToInventory (gameObject.tag);
				Destroy (this.gameObject);
			} else if(!(gameObject.tag.Equals(".40 S&W") || gameObject.tag.Equals(".45 ACP") || gameObject.tag.Equals("FN 5.7x28mm")) && game.GetComponent<InventoryManager>().inventoryFull){
				//display inventory is full
				game.GetComponent<UpgradeManager>().popUp.GetComponentInChildren<Text> ().text = "INVENTORY FULL";
				game.GetComponent<UpgradeManager> ().popUp.SetActive (true);
				tryToPickUp =true;
			} else{
				if (!game.GetComponent<GunManager> ().GetAmmoFull (gameObject.tag)) {
					game.GetComponent<GunManager> ().SetTotalAmmo (game.GetComponent<GunManager>().PickUpAmmo(), gameObject.tag);
					Destroy (this.gameObject);
				} else {
					//Display ammo of type gameObject.tag full
					game.GetComponent<UpgradeManager>().popUp.GetComponentInChildren<Text> ().text = "AMMO TYPE:\n" + gameObject.tag + "\nIS FULL";
					game.GetComponent<UpgradeManager> ().popUp.SetActive (true);
					tryToPickUp =true;
				}
			}
			pickUpDelay = 20f;
		}
	}

}
