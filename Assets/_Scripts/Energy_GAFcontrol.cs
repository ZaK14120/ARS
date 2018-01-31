using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAF.Core;

public class Energy_GAFcontrol : MonoBehaviour {

	public GAFBakedMovieClip Clip;
	public int frameNo;
	public static Energy_GAFcontrol instance;

	// Use this for initialization
	void Awake(){
		instance = this;
	}

	void Start () {
		frameNo = (int)Clip.currentFrameNumber;
		Clip.gotoAndPlay (1);
	}
	
	// Update is called once per frame
	void Update () {
//		if (TimeRemaining > 10f) {
//			Clip.gotoAndPlay (1);
//		}

		if (Clip.internalFrameNumber == 240) {
			
			Game3Manager.instance.GameOver3 ();
		}
	}


	public void RenewEnergy(){
		Clip.gotoAndPlay (1);
	}
}
