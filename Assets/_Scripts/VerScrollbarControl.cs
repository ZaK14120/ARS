using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerScrollbarControl : MonoBehaviour {

	public Scrollbar VerScroll;
	// Use this for initialization
	void Start () {
		VerScroll = GetComponent<Scrollbar> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnEnable(){
		VerScroll.value = 1;
	}

	void OnDisable(){
		VerScroll.value = 1;
	}
}
