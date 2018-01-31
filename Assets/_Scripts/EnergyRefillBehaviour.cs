using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRefillBehaviour : MonoBehaviour {

	public Vector3 Direction;
	public float rotateSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Direction * rotateSpeed);
	}

	public void OnTriggerEnter(Collider col){
		if (col.tag == "Dog") {
			PlayerEnergy.instance.RenewEnergy ();
			Energy_GAFcontrol.instance.RenewEnergy ();
			gameObject.SetActive (false);


			Invoke ("ReActivate", 10f);
		}
		
	}

	public void ReActivate(){
		gameObject.SetActive (true);
	}
}
