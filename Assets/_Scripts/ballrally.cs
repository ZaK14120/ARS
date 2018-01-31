using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ballrally : MonoBehaviour {

	public GameObject player, character, ball;

	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		//DOTween.To(
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
