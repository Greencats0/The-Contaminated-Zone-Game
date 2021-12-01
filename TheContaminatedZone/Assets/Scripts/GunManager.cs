using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunManager : MonoBehaviour {
	public GameObject pm40;
	public GameObject gun1911;
	public GameObject fn57;
	public GameObject pm402;
	public GameObject gun19112;
	public GameObject fn572;
	public GameObject rotator;
	public GameObject rotator2;
	public Text ammoRatio;
	public Text ammoRatio2;
	public UpgradeManager upgrades;
	public PreferenceManager preference;
	public Text damageUpgradePM40;
	public Text magUpgradePM40;
	public Text ammoUpgradePM40;
	public Text damageUpgrade1911;
	public Text magUpgrade1911;
	public Text ammoUpgrade1911;
	public Text damageUpgradeFN57;
	public Text magUpgradeFN57;
	public Text ammoUpgradeFN57;
	public Text ammoDropUpgrade;
	private float totalAmmoCapacityPM40 = 60;
	private float totalAmmoCapacity1911 = 80;
	private float totalAmmoCapacityFN57 = 120;
	private float magCapacityPM40 = 5;//.40 S&W ammo type && extended mag is 6
	private float magCapacity1911 = 8;//.45 ACP ammo type && extended mag 10
	private float magCapacityFN57 = 10;//FN 5.7x28mm ammo type && mag size range(10 restricted, 20 standard, 30 extended)
	private float totalAmmoPM40;
	private float totalAmmo1911;
	private float totalAmmoFN57;
	private float currentAmmoInMagPM40;
	private float currentAmmoInMag1911;
	private float currentAmmoInMagFN57;
	private string currentGun;
	// Use this for initialization
	void Awake () {
		if (PreferenceManager.shootingHand == 0) {
			pm40.SetActive (true);
			gun1911.SetActive (false);
			fn57.SetActive (false);
		} else if (PreferenceManager.shootingHand == 1) {
			pm402.SetActive (true);
			gun19112.SetActive (false);
			fn572.SetActive (false);
		}
		currentGun = "PM40";
		totalAmmoPM40 = 30;
		totalAmmo1911 = 40;
		totalAmmoFN57 = 60;
		currentAmmoInMagPM40 = 5;
		currentAmmoInMag1911 = 8;
		currentAmmoInMagFN57 = 10;

	}
	void Start () {
		ChangeGunHold ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentGun.Equals ("PM40")) {
			ammoRatio.text = currentAmmoInMagPM40 + "/" + totalAmmoPM40;
			ammoRatio2.text = currentAmmoInMagPM40 + "/" + totalAmmoPM40;
		} else if (currentGun.Equals ("1911")) {
			ammoRatio.text = currentAmmoInMag1911 + "/" + totalAmmo1911;
			ammoRatio2.text = currentAmmoInMag1911 + "/" + totalAmmo1911;
		} else if (currentGun.Equals ("FN57")) {
			ammoRatio.text = currentAmmoInMagFN57 + "/" + totalAmmoFN57;
			ammoRatio2.text = currentAmmoInMagFN57 + "/" + totalAmmoFN57;
		}
		ChangeGunHold ();
	}

	public float GetCurrentAmmoInMag(){
		if (currentGun.Equals ("PM40")) {
			return currentAmmoInMagPM40;
		} else if (currentGun.Equals ("1911")) {
			return currentAmmoInMag1911;
		} else if (currentGun.Equals ("FN57")) {
			return currentAmmoInMagFN57;
		}
		return 0;
			
	}

	public float GetMagCapacity(){
		if (currentGun.Equals ("PM40")) {
			return magCapacityPM40;
		} else if (currentGun.Equals ("1911")) {
			return magCapacity1911;
		} else if (currentGun.Equals ("FN57")) {
			return magCapacityFN57;
		}
		return 0;
	}

	public float GetTotalAmmo(){
		if (currentGun.Equals ("PM40")) {
			return totalAmmoPM40;
		} else if (currentGun.Equals ("1911")) {
			return totalAmmo1911;
		} else if (currentGun.Equals ("FN57")) {
			return totalAmmoFN57;
		}
		return 0;
	}

	public float GetTotalAmmoCapacity(){
		if (currentGun.Equals ("PM40")) {
			return totalAmmoCapacityPM40;
		} else if (currentGun.Equals ("1911")) {
			return totalAmmoCapacity1911;
		} else if (currentGun.Equals ("FN57")) {
			return totalAmmoCapacityFN57;
		}
		return 0;
	}

	public void SetAmmoInMag(float ammo){
		if (currentGun.Equals ("PM40")) {
			currentAmmoInMagPM40 = ammo;
		} else if (currentGun.Equals ("1911")) {
			currentAmmoInMag1911 = ammo;
		} else if (currentGun.Equals ("FN57")) {
			currentAmmoInMagFN57 = ammo;
		}
	}

	public void SetTotalAmmoCapPM40(){
		upgrades.ammoUpgradePM40++;
		if (upgrades.ammoUpgradePM40 == 1) {
			upgrades.upgradePoints -= 2;
			ammoUpgradePM40.text = "60->100";
		} else if(upgrades.ammoUpgradePM40 == 2){
			upgrades.upgradePoints -= 3;
			ammoUpgradePM40.text = "100->140";
		} else if(upgrades.ammoUpgradePM40 == 3){
			upgrades.upgradePoints -= 4;
			ammoUpgradePM40.text = "140(MAX)";
		}
		totalAmmoCapacityPM40 = 60 + 40 * upgrades.ammoUpgradePM40;
	}
	public void SetTotalAmmoCap1911(){
		upgrades.ammoUpgrade1911++;
		if (upgrades.ammoUpgrade1911 == 1) {
			upgrades.upgradePoints -= 2;
			ammoUpgrade1911.text = "80->120";
		} else if(upgrades.ammoUpgrade1911 == 2){
			upgrades.upgradePoints -= 3;
			ammoUpgrade1911.text = "120->160";
		} else if(upgrades.ammoUpgrade1911 == 3){
			upgrades.upgradePoints -= 4;
			ammoUpgrade1911.text = "160(MAX)";
		}
		totalAmmoCapacity1911 = 80 + 40 * upgrades.ammoUpgrade1911;
	}
	public void SetTotalAmmoCapFN57(){
		upgrades.ammoUpgradeFN57++;
		if (upgrades.ammoUpgradeFN57 == 1) {
			upgrades.upgradePoints -= 2;
			ammoUpgradeFN57.text = "120->160";
		} else if(upgrades.ammoUpgradeFN57 == 2){
			upgrades.upgradePoints -= 3;
			ammoUpgradeFN57.text = "160->200";
		} else if(upgrades.ammoUpgradeFN57 == 3){
			upgrades.upgradePoints -= 4;
			ammoUpgradeFN57.text = "200(MAX)";
		}
		totalAmmoCapacityFN57 = 120 + 40 * upgrades.ammoUpgradeFN57;
	}

	public void SetMagAmmoCapPM40(){
		upgrades.magUpgradePM40++;
		upgrades.upgradePoints -= 4;
		magUpgradePM40.text = "6(MAX)";
		magCapacityPM40 = 5 + 1* upgrades.magUpgradePM40;
	}
	public void SetMagAmmoCap1911(){
		upgrades.magUpgrade1911++;
		upgrades.upgradePoints -= 4;
		magUpgrade1911.text = "10(MAX)";
		magCapacity1911 = 8 + 2 * upgrades.magUpgrade1911;
	}
	public void SetMagAmmoCapFN57(){
		upgrades.magUpgradeFN57++;
		if (upgrades.magUpgradeFN57 == 1) {
			upgrades.upgradePoints -= 5;
			magUpgradeFN57.text = "20->30";
		} else if (upgrades.magUpgradeFN57 == 2) {
			upgrades.upgradePoints -= 6;
			magUpgradeFN57.text = "30(MAX)";
		}
		magCapacityFN57 = 10 + 10 * upgrades.magUpgradeFN57;
	}

	public void SetTotalAmmo(float ammoLeft){
		if (currentGun.Equals ("PM40")) {
			totalAmmoPM40 = ammoLeft;
		} else if (currentGun.Equals ("1911")) {
			totalAmmo1911 = ammoLeft;
		} else if (currentGun.Equals ("FN57")) {
			totalAmmoFN57 = ammoLeft;
		}
	}

	public void SetTotalAmmo(float ammo, string ammoType){
		if (ammoType.Equals (".40 S&W")) {
			totalAmmoPM40 += ammo;
		} else if (ammoType.Equals (".45 ACP")) {
			totalAmmo1911 += ammo;
		} else if (ammoType.Equals ("FN 5.7x28mm")) {
			totalAmmoFN57 += ammo;
		}
	}

	public bool GetAmmoFull(string ammoType){
		if (ammoType.Equals (".40 S&W") && totalAmmoPM40 == totalAmmoCapacityPM40) {
			return true;
		} else if (ammoType.Equals (".45 ACP") && totalAmmo1911 == totalAmmoCapacity1911) {
			return true;
		} else if (ammoType.Equals ("FN 5.7x28mm") && totalAmmoFN57 == totalAmmoCapacityFN57) {
			return true;
		}
		return false;
	}

	public void SwapGun(){
		if (PreferenceManager.shootingHand == 0) {
			if (currentGun.Equals ("PM40")) {
				if (upgrades.gun1911Unlocked) {
					pm40.SetActive (false);
					gun1911.SetActive (true);
					currentGun = "1911";
				} else if (upgrades.gunFN57Unlocked) {
					pm40.SetActive (false);
					fn57.SetActive (true);
					currentGun = "FN57";
				}
			} else if (currentGun.Equals ("1911")) {
				if (upgrades.gunFN57Unlocked) {
					gun1911.SetActive (false);
					fn57.SetActive (true);
					currentGun = "FN57";
				} else {
					gun1911.SetActive (false);
					pm40.SetActive (true);
					currentGun = "PM40";
				}
			} else if (currentGun.Equals ("FN57")) {
				fn57.SetActive (false);
				pm40.SetActive (true);
				currentGun = "PM40";
			}
		} else if (PreferenceManager.shootingHand == 1) {
			if (currentGun.Equals ("PM40")) {
				if (upgrades.gun1911Unlocked) {
					pm402.SetActive (false);
					gun19112.SetActive (true);
					currentGun = "1911";
				} else if (upgrades.gunFN57Unlocked) {
					pm402.SetActive (false);
					fn572.SetActive (true);
					currentGun = "FN57";
				}
			} else if (currentGun.Equals ("1911")) {
				if (upgrades.gunFN57Unlocked) {
					gun19112.SetActive (false);
					fn572.SetActive (true);
					currentGun = "FN57";
				} else {
					gun19112.SetActive (false);
					pm402.SetActive (true);
					currentGun = "PM40";
				}
			} else if (currentGun.Equals ("FN57")) {
				fn572.SetActive (false);
				pm402.SetActive (true);
				currentGun = "PM40";
			}
		}
	}

	public void SwitchToCurrent(){
		if (PreferenceManager.shootingHand == 0) {
			if (currentGun.Equals ("PM40")) {
				pm40.SetActive (true);
				gun1911.SetActive (false);
				fn57.SetActive (false);
			} else if (currentGun.Equals ("1911")) {
				gun1911.SetActive (true);
				pm40.SetActive (false);
				fn57.SetActive (false);
			} else if (currentGun.Equals ("FN57")) {
				fn57.SetActive (true);
				gun1911.SetActive (false);
				pm40.SetActive (false);
			}
		} else if (PreferenceManager.shootingHand == 1) {
			if (currentGun.Equals ("PM40")) {
				pm402.SetActive (true);
				fn572.SetActive (false);
				gun19112.SetActive (false);
			} else if (currentGun.Equals ("1911")) {
				gun19112.SetActive (true);
				pm402.SetActive (false);
				fn572.SetActive (false);
			} else if (currentGun.Equals ("FN57")) {
				fn572.SetActive (true);
				pm402.SetActive (false);
				gun19112.SetActive (false);
			}
		}
	}
	public void ChangeGunHold(){
		if (PreferenceManager.gunHold == 1) {
			rotator.transform.localEulerAngles = new Vector3 (0, 0, 0);
			rotator2.transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			rotator.transform.localEulerAngles= new Vector3 (-45, 0, 0);
			rotator2.transform.localEulerAngles= new Vector3 (-45, 0, 0);
		}
	}
	public void SetDamagePM40(){
		upgrades.damageUpgradePM40++;
		if (upgrades.damageUpgradePM40 == 1) {
			upgrades.upgradePoints -= 2;
			damageUpgradePM40.text = "10->15";
		} else if(upgrades.damageUpgradePM40 == 2){
			upgrades.upgradePoints -= 3;
			damageUpgradePM40.text = "15->20";
		} else if(upgrades.damageUpgradePM40 == 3){
			upgrades.upgradePoints -= 4;
			damageUpgradePM40.text = "20(MAX)";
		}
	}
	public void SetDamage1911(){
		upgrades.damageUpgrade1911++;
		if (upgrades.damageUpgrade1911 == 1) {
			upgrades.upgradePoints -= 2;
			damageUpgrade1911.text = "11->16";
		} else if(upgrades.damageUpgrade1911 == 2){
			upgrades.upgradePoints -= 3;
			damageUpgrade1911.text = "16->21";
		} else if(upgrades.damageUpgrade1911 == 3){
			upgrades.upgradePoints -= 4;
			damageUpgrade1911.text = "21(MAX)";
		}
	}
	public void SetDamageFN57(){
		upgrades.damageUpgradeFN57++;
		if (upgrades.damageUpgradeFN57 == 1) {
			upgrades.upgradePoints -= 2;
			damageUpgradeFN57.text = "15->20";
		} else if(upgrades.damageUpgradeFN57 == 2){
			upgrades.upgradePoints -= 3;
			damageUpgradeFN57.text = "20->25";
		} else if(upgrades.damageUpgradeFN57 == 3){
			upgrades.upgradePoints -= 4;
			damageUpgradeFN57.text = "25(MAX)";
		}
	}
	public void Unlock1911(){
		upgrades.upgradePoints -= 8;
		upgrades.gun1911Unlocked = true;
	}
	public void UnlockFN57(){
		upgrades.upgradePoints -= 15;
		upgrades.gunFN57Unlocked = true;
	}
	public float GetDamage(){
		if (currentGun.Equals ("PM40")) {
			return 5+5*upgrades.damageUpgradePM40;
		} else if (currentGun.Equals ("1911")) {
			return 6+5*upgrades.damageUpgrade1911;
		} else if (currentGun.Equals ("FN57")) {
			return 10+5*upgrades.damageUpgradeFN57;
		}
		return 0;
	}
	public void SetAmmoDrop(){
		upgrades.ammoDropUpgrade++;
		if (upgrades.ammoDropUpgrade == 1) {
			upgrades.upgradePoints -= 5;
			ammoDropUpgrade.text = "30->40";
		} else if (upgrades.ammoDropUpgrade == 2) {
			upgrades.upgradePoints -= 6;
			ammoDropUpgrade.text = "40->50";
		} else if (upgrades.ammoDropUpgrade == 3) {
			upgrades.upgradePoints -= 7;
			ammoDropUpgrade.text = "50->60";
		} else if (upgrades.ammoDropUpgrade == 4) {
			upgrades.upgradePoints -= 8;
			ammoDropUpgrade.text = "60(MAX)";
		}
	}
	public float PickUpAmmo(){
		return 20 + 10 * upgrades.ammoDropUpgrade;
	}





}
