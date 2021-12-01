using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceManager : MonoBehaviour {
	public static int gunHold = 0;
	public static int shootingHand = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchGunHoldStandard(){
		gunHold = 0;
	}

	public void SwitchGunHoldRealistic(){
		gunHold = 1;
	}

	public void SwitchShootingLeft(){
		shootingHand = 1;
	}

	public void SwitchShootingRight(){
		shootingHand = 0;
	}
}
