using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public GameObject gameOver;
	public GameObject youSurvived;
	public GameObject timer;
	public Image healthImage;
	public Image thirstImage;
	public Image hungerImage;
	public Text ratioTextHealth;
	public Text ratioTextThirst;
	public Text ratioTextHunger;
	public Image healthImage2;
	public Image thirstImage2;
	public Image hungerImage2;
	public Text ratioTextHealth2;
	public Text ratioTextThirst2;
	public Text ratioTextHunger2;
	public Image healthImageInv;
	public Image thirstImageInv;
	public Image hungerImageInv;
	public Text ratioTextHealthInv;
	public Text ratioTextThirstInv;
	public Text ratioTextHungerInv;
	public GameObject menu;
	public PlayerManager player;
	public UpgradeManager upgrades;
	public Text healthUpgrade;
	public Text thirstUpgrade;
	public Text hungerUpgrade;
	public AudioSource audio1;
	public AudioClip death;
	public AudioClip hurt;
	private float health=100;
	private float maxHealth=100;
	private float thirst = 100;
	private float maxThirst = 100;
	private float hunger = 100;
	private float maxHunger = 100;

	private float thirstDecayRate=900f;
	private float hungerDecayRate=900f;
	private float naturalHealthDecay=900f;
	private float naturalHealRate;
	private float naturalHealAmount;
	void Start(){
		gameOver.SetActive (false);
		youSurvived.SetActive (false);
		timer.SetActive (false);
	}

	void Update(){
		UpdateHunger ();
		UpdateThirst ();
		UpdateHealth ();
	}

	void FixedUpdate(){
		StatusUpdate ();
		UpdateHunger ();
		UpdateThirst ();
		UpdateHealth ();
	}
	private void UpdateHealth (){
		healthImage.fillAmount = health / maxHealth;
		ratioTextHealth.text = health + "/" + maxHealth;
		healthImageInv.fillAmount = health / maxHealth;
		ratioTextHealthInv.text = health + "/" + maxHealth;
		healthImage2.fillAmount = health / maxHealth;
		ratioTextHealth2.text = health + "/" + maxHealth;
	}

	private void TakeDamage(float damage){
		health -= damage;
		audio1.PlayOneShot (hurt);
		if (health <= 0) {
			health = 0;
			menu.SetActive (true);
			gameOver.SetActive (true);
			youSurvived.SetActive (true);
			timer.SetActive (true);
			for (int i = 0; i < player.walkers.Length; i++) {
				player.walkers [i].SetActive (false);
			}
			for (int i = 0; i < player.runners.Length; i++) {
				player.runners [i].SetActive (false);
			}
			audio1.PlayOneShot (death);
			Time.timeScale = 0;

		}
		UpdateHealth ();
	}
	private void StatusUpdate (){
		if (player.playerMoving) {
			hungerDecayRate -= 2f;
			thirstDecayRate -= 2f;
		} else {
			hungerDecayRate -= 1f;
			thirstDecayRate -= 1f;
		}
		if (hungerDecayRate <= 0f) {
			hungerDecayRate = 900f;
			hunger--;
		}
		if (thirstDecayRate <= 0f) {
			thirstDecayRate = 900f;
			thirst--;
		}
		if (hunger <= 0f || thirst <= 0f) {
			naturalHealthDecay -= 1f;
		} else if (thirst / maxThirst >= 0.8f && hunger / maxHunger >= 0.8f) {
			naturalHealRate -= 1f;
			if (naturalHealRate <= 0f) {
				naturalHealRate = 600f;
				Heal (1f);
			}
		}
		if (hunger < 0f) {
			hunger = 0f;
		}
		if (thirst < 0f) {
			thirst = 0f;
		}
		if (naturalHealthDecay <= 0f) {
			naturalHealthDecay = 900f;
			TakeDamage (1f);
		}
	}

	private void UpdateHunger(){
		hungerImage.fillAmount = hunger / maxHunger;
		ratioTextHunger.text = hunger + "/" + maxHunger;
		hungerImageInv.fillAmount = hunger / maxHunger;
		ratioTextHungerInv.text = hunger + "/" + maxHunger;
		hungerImage2.fillAmount = hunger / maxHunger;
		ratioTextHunger2.text = hunger + "/" + maxHunger;
	}

	private void UpdateThirst(){
		thirstImage.fillAmount = thirst / maxThirst;
		ratioTextThirst.text = thirst + "/" + maxThirst;
		thirstImageInv.fillAmount = thirst / maxThirst;
		ratioTextThirstInv.text = thirst + "/" + maxThirst;
		thirstImage2.fillAmount = thirst / maxThirst;
		ratioTextThirst2.text = thirst + "/" + maxThirst;
	}

	public void Eat(string item){
		if(item.Equals("Apple")){
			thirst += 5;
			hunger += 15;
			health += 0;
		} else if(item.Equals("Banana")){
			thirst += 0;
			hunger += 15;
			health += 0;
		} else if(item.Equals("Beer")){
			thirst += 20;
			hunger -= 5;
			health += 0;
		} else if(item.Equals("Bread")){
			thirst -= 5;
			hunger += 20;
			health += 0;
		} else if(item.Equals("Coke_Bottle")){
			thirst += 15;
			hunger += 5;
			health += 0;
		} else if(item.Equals("Coke_Can")){
			thirst += 10;
			hunger += 5;
			health += 0;
		} else if(item.Equals("Donut")){
			thirst -= 5;
			hunger += 20;
			health += 0;
		} else if(item.Equals("MedKit")){
			thirst += 0;
			hunger += 0;
			health += 50;
		} else if(item.Equals("Water")){
			thirst += 15;
			hunger += 0;
			health += 0;
		}
		if (health > maxHealth) {
			health = maxHealth;
		} else if(health < 0){
			health = 0;
		}
		if (thirst > maxThirst) {
			thirst = maxThirst;
		} else if(thirst < 0){
			thirst = 0;
		}
		if (hunger > maxHunger) {
			hunger = maxHunger;
		} else if(hunger < 0){
			hunger = 0;
		}
	}
	private void Heal(float heal){
		health += heal;
		if (health >= maxHealth) {
			health = maxHealth;

		}
		UpdateHealth ();
	}

	public float GetPlayerHealth(){
		return health;
	}

	public void SetHealthCap(){
		upgrades.healthUpgrade++;
		maxHealth = 100 + 50 * upgrades.healthUpgrade;
		if (upgrades.healthUpgrade == 1) {
			upgrades.upgradePoints -= 2;
			healthUpgrade.text = "150->200";
		} else if(upgrades.healthUpgrade == 2){
			upgrades.upgradePoints -= 3;
			healthUpgrade.text = "200->250";
		} else if(upgrades.healthUpgrade == 3){
			upgrades.upgradePoints -= 4;
			healthUpgrade.text = "250(MAX)";
		}
	}

	public void SetThirstCap(){
		upgrades.thirstUpgrade++;
		maxThirst = 100 + 50 * upgrades.thirstUpgrade;
		if (upgrades.thirstUpgrade == 1) {
			upgrades.upgradePoints -= 2;
			thirstUpgrade.text = "150->200";
		} else if(upgrades.thirstUpgrade == 2){
			upgrades.upgradePoints -= 3;
			thirstUpgrade.text = "200->250";
		} else if(upgrades.thirstUpgrade == 3){
			upgrades.upgradePoints -= 4;
			thirstUpgrade.text = "250(MAX)";
		}
	}

	public void SetHungerCap(){
		upgrades.hungerUpgrade++;
		maxHunger = 100 + 50 * upgrades.hungerUpgrade;
		if (upgrades.hungerUpgrade == 1) {
			upgrades.upgradePoints -= 2;
			hungerUpgrade.text = "150->200";
		} else if(upgrades.hungerUpgrade == 2){
			upgrades.upgradePoints -= 3;
			hungerUpgrade.text = "200->250";
		} else if(upgrades.hungerUpgrade == 3){
			upgrades.upgradePoints -= 4;
			hungerUpgrade.text = "250(MAX)";
		}
	}


}
