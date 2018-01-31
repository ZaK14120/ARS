using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorScrollbarControl : MonoBehaviour {

	public Scrollbar HorScroll;
	// Use this for initialization
	void Start () {
		HorScroll = GetComponent<Scrollbar> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		HorScroll.value = 1;
	}

	void OnDisable(){
		HorScroll.value = 1;
	}
}
