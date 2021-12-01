using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GameManager : MonoBehaviour {

	public GameObject controllerLeft;
	public GameObject controllerRight;
	public GameObject menu;
	public GameObject inventoryUpgradeTabs;
	public GunManager guns;
	public GameObject guns1;
	public GameObject guns2;
	public GameObject timer;
	public GameObject timer2;
	public GameObject leftModel;
	public GameObject rightModel;
	public MainMenuManager main;
	public PreferenceManager preference;
	private float swapDelay=20f;
	private float menuDelay=20f;
	private SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Awake(){
		Time.timeScale = 1;
		menu.SetActive (false);
		inventoryUpgradeTabs.SetActive (false);
		//controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
		controllerLeft.GetComponent<VRTK_Pointer> ().enabled = false;
		//controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
		controllerRight.GetComponent<VRTK_Pointer> ().enabled = false;
		controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = false;
		controllerRight.GetComponent<VRTK_UIPointer> ().enabled = false;


	}
	void Start () {
		//Time.timeScale = 0;
		if (PreferenceManager.shootingHand == 0) {
			controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
			controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
			controllerLeft.GetComponent<VRTK_Pointer> ().enabled = true;
			controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = true;
			controllerRight.GetComponent<VRTK_Pointer> ().enabled = false;
			controllerRight.GetComponent<VRTK_UIPointer> ().enabled = false;
		} else if (PreferenceManager.shootingHand == 1) {
			controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
			controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
			controllerRight.GetComponent<VRTK_Pointer> ().enabled = true;
			controllerRight.GetComponent<VRTK_UIPointer> ().enabled = true;
			controllerLeft.GetComponent<VRTK_Pointer> ().enabled = false;
			controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = false;
		}
	}

	void FixedUpdate(){
		if (swapDelay > 0) {
			swapDelay -= 1;
		}

	}

	// Update is called once per frame
	void Update () {
		var controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
		var controllerEvents2 = controllerRight.GetComponent<VRTK_ControllerEvents> ();
		if (PreferenceManager.shootingHand == 0) {
			controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
			controllerEvents2 = controllerRight.GetComponent<VRTK_ControllerEvents> ();
			controllerLeft.GetComponent<VRTK_TouchpadWalking> ().enabled = true;
			controllerRight.GetComponent<VRTK_TouchpadWalking> ().enabled = false;
			guns1.SetActive (true);
			guns2.SetActive (false);
			timer.SetActive (true);
			timer2.SetActive (false);
			leftModel.SetActive (true);
			rightModel.SetActive (false);
		} else if(PreferenceManager.shootingHand == 1){
			controllerEvents = controllerRight.GetComponent<VRTK_ControllerEvents> ();
			controllerEvents2 = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
			controllerLeft.GetComponent<VRTK_TouchpadWalking> ().enabled = false;
			controllerRight.GetComponent<VRTK_TouchpadWalking> ().enabled = true;
			guns2.SetActive (true);
			guns1.SetActive (false);
			timer2.SetActive (true);
			timer.SetActive (false);
			leftModel.SetActive (false);
			rightModel.SetActive (true);
		}
		guns.SwitchToCurrent ();
		//var controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
		//var controllerEvents2= controllerRight.GetComponent<VRTK_ControllerEvents> ();

		if (menuDelay > 0) {
			menuDelay -= 1;
		}
		if (Time.timeScale == 1 && !this.GetComponent<MainMenuManager>().beginning) {
			controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
			controllerLeft.GetComponent<VRTK_Pointer> ().enabled = false;
			controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = false;
			controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
			controllerRight.GetComponent<VRTK_Pointer> ().enabled = false;
			controllerRight.GetComponent<VRTK_UIPointer> ().enabled = false;
			if ((Input.GetKeyDown ("escape") || controllerEvents.IsButtonPressed (VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress)) && menuDelay == 0) {
				Time.timeScale = 0;
				menu.SetActive (true);
				if (PreferenceManager.shootingHand == 0) {
					controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
					controllerLeft.GetComponent<VRTK_Pointer> ().enabled = true;
					controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = true;
				} else if (PreferenceManager.shootingHand == 1) {
					controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
					controllerRight.GetComponent<VRTK_Pointer> ().enabled = true;
					controllerRight.GetComponent<VRTK_UIPointer> ().enabled = true;
				}
				menuDelay = 20f;

			} else if ((Input.GetKeyDown ("escape") || controllerEvents2.IsButtonPressed (VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress)) && menuDelay == 0) {
				Time.timeScale = 0;
				inventoryUpgradeTabs.SetActive (true);
				if (PreferenceManager.shootingHand == 0) {
					controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
					controllerLeft.GetComponent<VRTK_Pointer> ().enabled = true;
					controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = true;
				} else if (PreferenceManager.shootingHand == 1) {
					controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
					controllerRight.GetComponent<VRTK_Pointer> ().enabled = true;
					controllerRight.GetComponent<VRTK_UIPointer> ().enabled = true;
				}
				menuDelay = 20f;
			}
		} else if(!this.GetComponent<MainMenuManager>().beginning) {
			if (PreferenceManager.shootingHand == 0) {
				controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
				controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
				controllerLeft.GetComponent<VRTK_Pointer> ().enabled = true;
				controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = true;
				controllerRight.GetComponent<VRTK_Pointer> ().enabled = false;
				controllerRight.GetComponent<VRTK_UIPointer> ().enabled = false;
			} else if (PreferenceManager.shootingHand == 1) {
				controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
				controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
				controllerLeft.GetComponent<VRTK_Pointer> ().enabled = false;
				controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = false;
				controllerRight.GetComponent<VRTK_Pointer> ().enabled = true;
				controllerRight.GetComponent<VRTK_UIPointer> ().enabled = true;
			}
			if ((Input.GetKeyDown("escape") || controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress)) && menuDelay==0 && !inventoryUpgradeTabs.activeInHierarchy) {
				Time.timeScale = 1;
				main.SetMenuActive ();
				menuDelay = 20f;
			} else if ((Input.GetKeyDown("escape") || controllerEvents2.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress)) && menuDelay==0 && !main.GetMenuActive()) {
				Time.timeScale = 1;
				inventoryUpgradeTabs.SetActive (false);
				if (PreferenceManager.shootingHand == 0) {
					controllerLeft.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects ();
					controllerLeft.GetComponent<VRTK_Pointer> ().enabled = false;
					controllerLeft.GetComponent<VRTK_UIPointer> ().enabled = false;
				} else if (PreferenceManager.shootingHand == 1) {
					controllerRight.GetComponent<VRTK_StraightPointerRenderer> ().ResetPointerObjects();
					controllerRight.GetComponent<VRTK_Pointer> ().enabled = false;
					controllerRight.GetComponent<VRTK_UIPointer> ().enabled = false;
				}
				menuDelay = 20f;
			}

		} else if(this.GetComponent<MainMenuManager>().beginning){
			Time.timeScale = 0;
		}
		if ((Input.GetKeyDown ("f") || controllerEvents.IsButtonPressed (VRTK_ControllerEvents.ButtonAlias.TouchpadPress)) && swapDelay == 0) {
			guns.SwapGun ();
			swapDelay = 20f;
		}

	}
}
