using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
	public Text timer;
	public Text timer2;
	public Text timer3;
	public int minutes;
	public int seconds;
	public int hours;

	void Awake(){
		seconds = 0;
		minutes = 0;
		hours = 0;
	}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTime", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateTime(){
		seconds++;
		if (seconds == 60) {
			seconds = 0;
			minutes++;
			if (minutes == 60) {
				minutes = 60;
				hours++;
			}
		}
		if (seconds / 10 > 0) {
			if (minutes / 10 > 0) {
				timer.text = hours + ":" + minutes + ":" + seconds;
			} else {
				timer.text = hours + ":" + 0 + minutes + ":" + seconds;
			}
		} else {
			if (minutes / 10 > 0) {
				timer.text = hours + ":" + minutes + ":" + 0 + seconds;
			} else {
				timer.text = hours + ":" + 0 + minutes + ":" + 0 + seconds;
			}
		}
		timer2.text = timer.text;
		timer3.text = timer.text;
	}

	public void StopTimer(){
		CancelInvoke ();
	}
}
