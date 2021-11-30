using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class UpgradeManager : MonoBehaviour {

	public float upgradePoints;
	public GameObject popUp;
	public Text upgradePointsText;
	public float healthUpgrade;
	public float thirstUpgrade;
	public float hungerUpgrade;
	public float ammoDropUpgrade;
	public bool gun1911Unlocked;
	public bool gunFN57Unlocked;
	public float damageUpgradePM40;
	public float damageUpgrade1911;
	public float damageUpgradeFN57;
	public float magUpgradePM40;
	public float magUpgrade1911;
	public float magUpgradeFN57;
	public float ammoUpgradePM40;
	public float ammoUpgrade1911;
	public float ammoUpgradeFN57;
	public Button[] gunUnlockButtons;
	public Button[] damageButtons;
	public Button[] magSizeButtons;
	public Button[] ammoCapButtons;
	public Button[] playerUpgradeButtons;
	public float popUpTime = 250f;
	public bool keepActive;
	public bool isUpgrade;
	void Awake(){
		gun1911Unlocked = false;
		gunFN57Unlocked = false;
		damageUpgradePM40 = 0;
		damageUpgradeFN57 = 0;
		damageUpgrade1911 = 0;
		magUpgradePM40 = 0;
		magUpgradeFN57 = 0;
		magUpgrade1911 = 0;
		ammoUpgradePM40 = 0;
		ammoUpgradeFN57 = 0;
		ammoUpgrade1911 = 0;
		healthUpgrade = 0;
		thirstUpgrade = 0;
		hungerUpgrade = 0;
		popUp.SetActive (false);
		keepActive = false;
		isUpgrade = false;
	}
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (popUpTime > 0 && popUp.activeInHierarchy && isUpgrade) {
			popUpTime -= 1;
		}
		else if (popUpTime == 0 && popUp.activeInHierarchy && !keepActive) {
			popUp.SetActive (false);
			isUpgrade = false;
			popUpTime = 250f;
		}
		upgradePointsText.text = upgradePoints + "pts";
		CanBuy();
	}
		

	public void CanBuy(){
		if (upgradePoints >= 2 + damageUpgradePM40 && damageUpgradePM40 != 3) {
			damageButtons [0].interactable = true;
			damageButtons [0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + damageUpgradePM40) + "pts";
		} else if (damageUpgradePM40 == 3) {
			damageButtons [0].interactable = false;
			damageButtons [0].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			damageButtons [0].interactable = false;
			damageButtons [0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + damageUpgradePM40) + "pts";
		}
		if (upgradePoints >= 2 + damageUpgrade1911 && gun1911Unlocked) {
			damageButtons [1].interactable = true;
			damageButtons [1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + damageUpgrade1911) + "pts";
		} else if (damageUpgrade1911 == 3) {
			damageButtons [1].interactable = false;
			damageButtons [1].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			damageButtons [1].interactable = false;
			damageButtons [1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + damageUpgrade1911) + "pts";
		}
		if (upgradePoints >= 2 + damageUpgradeFN57 && gunFN57Unlocked) {
			damageButtons [2].interactable = true;
			damageButtons [2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + damageUpgradeFN57) + "pts";
		} else if (damageUpgradeFN57 == 3) {
			damageButtons [2].interactable = false;
			damageButtons [2].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			damageButtons [2].interactable = false;
			damageButtons [2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + damageUpgradeFN57) + "pts";
		}
		if (upgradePoints >= 2 + healthUpgrade && healthUpgrade!=3) {
			playerUpgradeButtons[0].interactable = true;
			playerUpgradeButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + healthUpgrade) + "pts";
		} else if (healthUpgrade ==3) {
			playerUpgradeButtons[0].interactable = false;
			playerUpgradeButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			playerUpgradeButtons[0].interactable = false;
			playerUpgradeButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + healthUpgrade) + "pts";
		}
		if (upgradePoints >= 2 + thirstUpgrade && thirstUpgrade!=3) {
			playerUpgradeButtons[1].interactable = true;
			playerUpgradeButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + thirstUpgrade) + "pts";
		} else if (thirstUpgrade ==3) {
			playerUpgradeButtons[1].interactable = false;
			playerUpgradeButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			playerUpgradeButtons[1].interactable = false;
			playerUpgradeButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + thirstUpgrade) + "pts";
		}
		if (upgradePoints >= 2 + hungerUpgrade&& hungerUpgrade!=3) {
			playerUpgradeButtons[2].interactable = true;
			playerUpgradeButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + hungerUpgrade) + "pts";
		} else if (hungerUpgrade ==3) {
			playerUpgradeButtons[2].interactable = false;
			playerUpgradeButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			playerUpgradeButtons[2].interactable = false;
			playerUpgradeButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + hungerUpgrade) + "pts";
		}
		if (upgradePoints >= 5 + hungerUpgrade&& ammoDropUpgrade!=4) {
			playerUpgradeButtons[3].interactable = true;
			playerUpgradeButtons[3].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (5 + ammoDropUpgrade) + "pts";
		} else if (ammoDropUpgrade ==4) {
			playerUpgradeButtons[3].interactable = false;
			playerUpgradeButtons[3].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			playerUpgradeButtons[3].interactable = false;
			playerUpgradeButtons[3].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (5 + ammoDropUpgrade) + "pts";
		}
		if (upgradePoints >= 4 && magUpgradePM40 != 1  && magUpgradePM40 != 1) {
			magSizeButtons[0].interactable = true;
			magSizeButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (4 + magUpgradePM40) + "pts";
		} else if (magUpgradePM40 == 1) {
			magSizeButtons[0].interactable = false;
			magSizeButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			magSizeButtons [0].interactable = false;
			magSizeButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (4 + magUpgradePM40) + "pts";
		}
		if (upgradePoints >= 4 && magUpgrade1911!=1 && gun1911Unlocked) {
			magSizeButtons[1].interactable = true;
			magSizeButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (4 + magUpgrade1911) + "pts";
		} else if (magUpgradePM40 == 1) {
			magSizeButtons [1].interactable = false;
			magSizeButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			magSizeButtons [1].interactable = false;
			magSizeButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (4 + magUpgrade1911) + "pts";
		}
		if (upgradePoints >= 5 + magUpgradeFN57 && magUpgradeFN57!=2 && gunFN57Unlocked) {
			magSizeButtons[2].interactable = true;
			magSizeButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (5 + magUpgradeFN57) + "pts";
		} else if (magUpgradePM40 == 2) {
			magSizeButtons [2].interactable = false;
			magSizeButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			magSizeButtons[2].interactable = false;
			magSizeButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (5 + magUpgradeFN57) + "pts";
		}
		if (upgradePoints >= 2 + ammoUpgradePM40 && ammoUpgradePM40!=2) {
			ammoCapButtons[0].interactable = true;
			ammoCapButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + ammoUpgradePM40) + "pts";
		} else if (ammoUpgradePM40==2) {
			ammoCapButtons[0].interactable = false;
			ammoCapButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			ammoCapButtons[0].interactable = false;
			ammoCapButtons[0].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + ammoUpgradePM40) + "pts";
		}

		if (upgradePoints >= 2 + ammoUpgrade1911 && ammoUpgrade1911!=2 && gun1911Unlocked) {
			ammoCapButtons[1].interactable = true;
			ammoCapButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + ammoUpgrade1911) + "pts";
		} else if (ammoUpgrade1911==2) {
			ammoCapButtons[1].interactable = false;
			ammoCapButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			ammoCapButtons[1].interactable = false;
			ammoCapButtons[1].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + ammoUpgrade1911) + "pts";
		}
		if (upgradePoints >= 2 + ammoUpgradeFN57 && ammoUpgradeFN57!=2 && gunFN57Unlocked) {
			ammoCapButtons[2].interactable = true;
			ammoCapButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + ammoUpgradeFN57) + "pts";
		} else if (ammoUpgradeFN57==2) {
			ammoCapButtons[2].interactable = false;
			ammoCapButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\nMAX";
		} else {
			ammoCapButtons[2].interactable = false;
			ammoCapButtons[2].GetComponentInChildren<Text> ().text = "UPGRADE\n" + (2 + ammoUpgradeFN57) + "pts";
		}
		if (gun1911Unlocked) {
			gunUnlockButtons [0].interactable = false;
			gunUnlockButtons [0].GetComponentInChildren<Text> ().text = "UNLOCKED";
		} else if (!gun1911Unlocked && upgradePoints >=8) {
			gunUnlockButtons [0].interactable = true;
			gunUnlockButtons [0].GetComponentInChildren<Text> ().text = "UNLOCK\n" + 8 + "pts";
		} else {
			gunUnlockButtons [0].interactable = false;
			gunUnlockButtons [0].GetComponentInChildren<Text> ().text = "UNLOCK\n" + 8 + "pts";
		}
		if (gunFN57Unlocked) {
			gunUnlockButtons [1].interactable = false;
			gunUnlockButtons [1].GetComponentInChildren<Text> ().text = "UNLOCKED";
		} else if (!gun1911Unlocked && upgradePoints >=15) {
			gunUnlockButtons [1].interactable = true;
			gunUnlockButtons [1].GetComponentInChildren<Text> ().text = "UNLOCK\n" + 15 + "pts";
		} else {
			gunUnlockButtons [1].interactable = false;
			gunUnlockButtons [1].GetComponentInChildren<Text> ().text = "UNLOCK\n" + 15 + "pts";
		}

	}

	public void RecieveUpgradePoint(float num){
		if (num == 1) {
			popUp.GetComponentInChildren<Text> ().text = "1 UPGRADEPOINT RECIEVED";
			upgradePoints++;
		} else if (num == 2) {
			popUp.GetComponentInChildren<Text> ().text = "2 UPGRADEPOINT RECIEVED";
			upgradePoints += 2;
		}
		popUp.SetActive (true);
		isUpgrade = true;
	}

		
}
