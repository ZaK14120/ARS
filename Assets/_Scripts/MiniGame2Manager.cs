using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MiniGame2Manager : MonoBehaviour {

	public Transform[] PassTarget;
	public Transform Ball, playerPivot;
	//public GameObject dog;
	public float ballspeed;
	public Ease easetype;
	private Transform currentTarget;
	bool isHit = true;
	public float timeLeft;


	void Start () {
		//Ball.position = playerPivot.position;

	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = timeLeft - Time.deltaTime;
		if (timeLeft == 0f) {
			GameOver ();
		}
		if (!isHit)
			return;
		else 
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
			HitTarget ();
		}






//		if(Input.GetAxis("Horizontal")
//			dog.transform.rotation(new Vector3(0,1,0));
	}

	public void HitTarget(){
		isHit = false;
		ActiveTarget ();
		Ball.DOMove (currentTarget.position, ballspeed, true).SetEase (easetype);
		//Ball.gameObject.SetActive (false);
		Invoke ("BallReset", 1f);


	}
	public void BallReset(){
		isHit = true;
		//Ball.position = playerPivot.position;
		Ball.position = new Vector3(0f,0.12f,-7.591f);
		//Ball.gameObject.SetActive (true);

	}
	public void ActiveTarget(){
		int myIndex = Random.Range (0, PassTarget.Length);
		currentTarget = PassTarget [myIndex];

		
	}
	public void GameOver(){
	
	}
}
