using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetBehaviour : MonoBehaviour {

	float moveSpeed;


	// Use this for initialization

	void Start () {

		varySpeed ();
		TargetMovementTo ();
	}
	
	// Update is called once per frame
	void Update () {


//		float PingPong(float t, float minLength , float maxLength ) {
//			return Mathf.PingPong(t, maxLength-minLength) + minLength;
//		}
//
//		transform.position = new Vector3 (PingPong (Time.time * moveSpeed, 1.79f,-1.79f), transform.position.y, transform.position.z);
//		transform.position = new Vector3 (Mathf.PingPong (Time.time * moveSpeed, 1.79f), transform.position.y, transform.position.z);
//		transform.position = new Vector3(transform.position.x + Mathf.PingPong(Time.time * moveSpeed, -1.79), transform.position.y, transform.position.z);


	}

	public void TargetMovementTo(){

		float moveTime = Vector3.Distance (new Vector3 (1.79f, transform.position.y, transform.position.z), new Vector3 (-1.79f, transform.position.y, transform.position.z)) / moveSpeed;
		transform.DOMove (new Vector3 (-1.79f, transform.position.y, transform.position.z), moveTime, false).SetEase(Ease.Linear).OnComplete (() => {
			transform.DOMove (new Vector3 (1.79f, transform.position.y, transform.position.z), moveTime , false).SetEase(Ease.Linear).OnComplete(()=>{
				TargetMovementTo();
			});
		});

	}


	public void Destroy()
	{
		//transform.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider col)
	{
//		if (col.tag == "ball") {
			//Destroy ();
		Game4Manager._instance.HideAllTargets();
		Game4Manager._instance.isTargetHit = true;
		Game4Manager._instance.DisplayScore ();
		Invoke("ShowTargetDelay", 0.5f);

//		}
	}

	public void varySpeed()
	{
		moveSpeed = Random.Range (0.3f, 2f);
	}

	void ShowTargetDelay()
	{
		Game4Manager._instance.ShowRandomTarget();

	}
}
