using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour {

	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		StartBlink ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Blink(){
		while (true) {
			switch (image.color.a.ToString ()) {
			case "0":
				image.color = new Color (image.color.r, image.color.g, image.color.b, 1f);
				yield return new WaitForSeconds (0.8f);
				break;
			case "1":
				image.color = new Color (image.color.r, image.color.g, image.color.b, 0f);
				yield return new WaitForSeconds (0.8f);
				break;
			}
		}
	}

	void StartBlink(){
		StopCoroutine ("Blink");
		StartCoroutine ("Blink");
	}
		
}
