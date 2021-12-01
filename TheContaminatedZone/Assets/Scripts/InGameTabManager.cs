using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameTabManager : MonoBehaviour {

	public GameObject inventoryButton;
	public GameObject upgradeButton;
	public GameObject inventoryTab;
	public GameObject upgradeTab;
	// Use this for initialization
	void Start () {
		inventoryTab.SetActive (true);
		inventoryButton.GetComponent<Button>().interactable =false;
		upgradeTab.SetActive (false);
		upgradeButton.GetComponent<Button>().interactable =true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchTabs(){
		if (inventoryTab.activeInHierarchy) {
			inventoryTab.SetActive (false);
			inventoryButton.GetComponent<Button>().interactable =true;
			upgradeTab.SetActive (true);
			upgradeButton.GetComponent<Button>().interactable =false;
		} else if (upgradeTab.activeInHierarchy) {
			inventoryTab.SetActive (true);
			inventoryButton.GetComponent<Button>().interactable =false;
			upgradeTab.SetActive (false);
			upgradeButton.GetComponent<Button>().interactable =true;
		}
	}
}
