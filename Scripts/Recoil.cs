
namespace VRTK.Examples
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZEffects;
using VRTK;
	public class Recoil : MonoBehaviour
	{


		private Animator anim;

		public EffectTracer tracerEffects;
		public Transform muzzleTransform;
		public GameObject controllerRight;
		public GunManager guns;

		public GameObject bulletPrefab;
		private SteamVR_TrackedObject trackedObj;
		//private VRTK_TrackedController controller;
		public AudioSource audio1;
		public AudioClip shot;
		public AudioClip empty;
		public AudioClip reload;
		public float audioDelay = 40.0f;
		void Start ()
		{
			
			anim = GetComponent<Animator> ();
			//controller = controllerRight.GetComponent<VRTK_TrackedController>();
			if (GetComponent<VRTK_ControllerEvents>() == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
				return;
			}
			//controller.GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(test);
			//controller.GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(testend);
		}

		void FixedUpdate(){
			if (audioDelay > 0) {
				audioDelay -= 1;
			}
		}
			
		// Update is called once per frame
		void Update ()
		{
		var controllerEvents = controllerRight.GetComponent<VRTK_ControllerEvents> ();
			AnimatorStateInfo state =anim.GetCurrentAnimatorStateInfo(0);
			if ((Input.GetMouseButtonDown(0) || controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TriggerClick)) && state.IsName("Idle") && guns.GetCurrentAmmoInMag()>1 && Time.timeScale!=0) {
				guns.SetAmmoInMag (guns.GetCurrentAmmoInMag() - 1);
				anim.Play ("Fire00", 0, 0f);
				muzzleEffect ();
				audio1.PlayOneShot (shot);
			}
			else if ((Input.GetMouseButtonDown(0) || controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TriggerClick)) && state.IsName("Idle") && guns.GetCurrentAmmoInMag()==1 && Time.timeScale!=0) {
				guns.SetAmmoInMag(0);
				anim.Play ("Fire01", 0, 0f);	
				muzzleEffect ();
				audio1.PlayOneShot (shot);

			}
			else if ((Input.GetMouseButtonDown(0) || controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TriggerClick)) && state.IsName("Fire01") && guns.GetCurrentAmmoInMag()==0 && Time.timeScale!=0 && audioDelay == 0) {
				audio1.PlayOneShot (empty);
				audioDelay = 40f;

			}
			if ((Input.GetKeyDown("r") || controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TouchpadPress)) && (state.IsName("Idle") || state.IsName("Fire01")) && Time.timeScale!=0) {
				if (guns.GetCurrentAmmoInMag() != 0) {
					anim.Play ("Reload00", 0, 0f);	
					if (guns.GetTotalAmmo() / guns.GetMagCapacity() >= 1) {
						guns.SetTotalAmmo (guns.GetTotalAmmo () - guns.GetMagCapacity () + guns.GetCurrentAmmoInMag ());
						guns.SetAmmoInMag (guns.GetMagCapacity());

					} else if(guns.GetTotalAmmo() + guns.GetCurrentAmmoInMag() >= guns.GetMagCapacity()){
						guns.SetTotalAmmo (guns.GetTotalAmmo () + guns.GetCurrentAmmoInMag() - guns.GetMagCapacity());
						guns.SetAmmoInMag (guns.GetMagCapacity());

					} else if(guns.GetTotalAmmo() % guns.GetMagCapacity() !=0){
						guns.SetAmmoInMag (guns.GetTotalAmmo ());
						guns.SetTotalAmmo (0);

					}
				} else {
					anim.Play ("Reload01", 0, 0f);
					if (guns.GetTotalAmmo() / guns.GetMagCapacity() >= 1) {
						guns.SetAmmoInMag (guns.GetMagCapacity());
						guns.SetTotalAmmo (guns.GetTotalAmmo () - guns.GetMagCapacity ());
					} else if(guns.GetTotalAmmo() % guns.GetMagCapacity() !=0){
						guns.SetAmmoInMag (guns.GetTotalAmmo ());
						guns.SetTotalAmmo (0);
					}
				}
				audio1.PlayOneShot (reload);
			}
		}

		private void test (object sender, ControllerInteractionEventArgs e) {
			Debug.Log ("trigger pulled");
		}

		private void testend (object sender, ControllerInteractionEventArgs e) {
			Debug.Log ("trigger unclicked");
		}
		void muzzleEffect ()
		{
       		// Add velocity to the bullet
			RaycastHit hit = new RaycastHit ();
			Ray ray = new Ray (muzzleTransform.position, muzzleTransform.forward);
			var bullet = (GameObject)Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100f;
        	//tracerEffects.ShowTracerEffect (muzzleTransform.position, muzzleTransform.forward, 250f);
        	if (Physics.Raycast (ray, out hit, 500f)) {
        	//If the bullet hit or not
				if (hit.rigidbody != null) {
					if (hit.rigidbody.gameObject.CompareTag ("Walker")) {
						hit.rigidbody.gameObject.SendMessage ("TakeDamage", guns.GetDamage());
						Destroy (bullet, hit.distance / 100f);
						//Debug.Log ("enemy took " + guns.GetDamage() + " damage");
					} else if (hit.rigidbody.gameObject.CompareTag ("Runner")) {
						hit.rigidbody.gameObject.SendMessage ("TakeDamage", guns.GetDamage());
						Destroy (bullet, hit.distance / 100f);
						//Debug.Log ("enemy took " + guns.GetDamage() + " damage");
					} 
				}else {
					Destroy (bullet, hit.distance / 100f);
				}
        	}
			Destroy (bullet, 2f);
    	}

	}

}
