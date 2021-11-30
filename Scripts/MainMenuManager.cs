using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject controllerLeft;
	public GameObject controllerRight;
	public GameObject settings;
	public GameObject menu;
	public GameObject credits;
	public GameObject gunHand;
	public GameObject gunAngle;
	public GameObject exit;
	public GameObject helpP1;
	public GameObject helpP2;
	public GameObject helpP3;
	public GameObject helpP4;
	public GameObject helpShoot;
	public GameObject helpMove;
	public GameObject startHelp;
	public GameObject endHelp;
	private float menuDelay=20f;
	private SteamVR_TrackedObject trackedObj;
	public bool beginning;
	// Use this for initialization
	void Awake(){
		beginning = false;
		if (SceneManager.GetActiveScene().buildIndex== 0) {
			menu.SetActive (true);
			startHelp.SetActive (false);
		} else {
			menu.SetActive (false);
			beginning = true;
			startHelp.SetActive (true);
		}
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
		endHelp.SetActive (false);
	}
	void Start () {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			menu.SetActive (true); 
			helpShoot.SetActive (false);
		} else {
			menu.SetActive (false);
			beginning = true;
			helpShoot.SetActive (true);
		}
	}

	void FixedUpdate(){

	}

	// Update is called once per frame
	void Update () {
		var controllerEvents = controllerLeft.GetComponent<VRTK_ControllerEvents> ();
		if (menuDelay > 0) {
			menuDelay -= 1;
		}
		if ((Input.GetMouseButtonDown (0) || controllerEvents.IsButtonPressed (VRTK_ControllerEvents.ButtonAlias.TriggerClick)) && menuDelay == 0) {		
			menuDelay = 20;
		}
	}

	public bool GetMenuActive(){
		if (menu.activeInHierarchy || settings.activeInHierarchy || helpMove.activeInHierarchy || helpP1.activeInHierarchy || helpP2.activeInHierarchy || helpP3.activeInHierarchy || helpP4.activeInHierarchy || helpShoot.activeInHierarchy || credits.activeInHierarchy || exit.activeInHierarchy || gunHand.activeInHierarchy || gunAngle.activeInHierarchy) {
			return true;
		}
		return false;
	}
	public void SetMenuActive(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToMain(){
		menu.SetActive (true);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToSettings(){
		menu.SetActive (false);
		settings.SetActive (true);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToShoot(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		if (beginning) {
			startHelp.SetActive (true);
		} else {
			helpShoot.SetActive (true);
		}
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToMove(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (true);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		startHelp.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToHelp1(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (true);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToHelp2(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (true);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToHelp3(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (true);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToHelp4(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		if (beginning) {
			endHelp.SetActive (true);
		}else {
			helpP4.SetActive (true);
		}
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
		
	public void GoToCredits(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (true);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToExit(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (true);
		gunHand.SetActive (false);
		gunAngle.SetActive (false);
	}
	public void GoToHand(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (true);
		gunAngle.SetActive (false);
	}
	public void GoToAngle(){
		menu.SetActive (false);
		settings.SetActive (false);
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		credits.SetActive (false);
		exit.SetActive (false);
		gunHand.SetActive (false);
		gunAngle.SetActive (true);
	}
	public void GoToGame(){
		SceneManager.LoadScene("Main"); // loads current scene
	}

	public void StartGame(){
		helpMove.SetActive (false);
		helpP1.SetActive (false);
		helpP2.SetActive (false);
		helpP3.SetActive (false);
		helpP4.SetActive (false);
		helpShoot.SetActive (false);
		startHelp.SetActive (false);
		endHelp.SetActive (false);
		beginning = false;
		Time.timeScale = 1;
	}
	public void Exit(){
		if (!Application.isEditor) {
			Application.Quit ();
			System.Diagnostics.Process.GetCurrentProcess ().Kill ();
		} else {
			//UnityEditor.EditorApplication.isPlaying = false;
		}


	}

}
