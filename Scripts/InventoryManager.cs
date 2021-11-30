using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public Button[] inventorySlots;
	public bool[] slot= new bool[15];
	public bool inventoryFull;
	public int movedIndex;
	public Sprite[] sprites;
	public GameObject game;
	// Use this for initialization
	void Start () {
		inventoryFull = false;
		for (int i = 0; i < slot.Length; i++) {
			slot [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addToInventory(string type){
		int index = 0;
		while (slot [index]) {
			index++;
		}
		slot [index] = true;
		if (index == slot.Length -1) {
			inventoryFull = true;
		}
		if(type.Equals("Apple")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[0];
		} else if(type.Equals("Banana")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[1];
		} else if(type.Equals("Beer")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[2];
		} else if(type.Equals("Bread")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[3];
		} else if(type.Equals("CokeBottle")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[4];
		} else if(type.Equals("CokeCan")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[5];
		} else if(type.Equals("Donut")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[6];
		} else if(type.Equals("MedKit")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[7];
		} else if(type.Equals("Water")){
			inventorySlots [index].GetComponent<Image> ().sprite = sprites[8];
		}
	}
	public void removeFromInventory(int slotIndex){
		game.GetComponent<PlayerHealth> ().Eat (inventorySlots [slotIndex].GetComponent<Image> ().sprite.name);
		while (slotIndex < slot.Length-1 && slot[slotIndex+1]) {
			inventorySlots [slotIndex].GetComponent<Image> ().sprite = inventorySlots [slotIndex+1].GetComponent<Image> ().sprite;
			slot [slotIndex] = slot [slotIndex + 1];
			slotIndex += 1;
		}
		slot [slotIndex] = false;
		inventorySlots [slotIndex].GetComponent<Image> ().sprite = sprites [9];
	}

}
