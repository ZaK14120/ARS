using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour {


	public Slider EnergyBar;
//	public GameObject EnergyPack;
	public float depletionTime, startingTime, TimeRemaining, TRIP;

	public static PlayerEnergy instance;

	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		EnergyBar.value = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		EnergyBar.value = UpdateTimer ();
//		if(TimeRemaining>5f){
//			startingTime = Time.time;
//		}

//		if (EnergyBar.value == 0f) {
//			Game3Manager.instance.GameOver3 ();
//		}
	}

//	float CalculateEnergy(){
//		return currentEnergy / MaxEnergy;
//	}

	 public float UpdateTimer(){
		TimeRemaining = depletionTime + startingTime - Time.time;
		TRIP = TimeRemaining / depletionTime;
		return TRIP;
	}

	public void RenewEnergy(){

//		startingTime += 2.5f;

//		if (TimeRemaining > 10) {
//			startingTime = startingTime - (TimeRemaining - depletionTime); 
//		}

		startingTime = Time.time;

	}
}
