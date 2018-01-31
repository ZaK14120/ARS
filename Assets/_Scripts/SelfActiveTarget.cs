using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfActiveTarget : MonoBehaviour {
	public GameObject Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){

		Target.SetActive (true);
	}

	void OnDisable(){

		Target.SetActive (false);
	}
}
