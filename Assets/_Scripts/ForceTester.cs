using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;


public class ForceTester : MonoBehaviour {
	public float forcePower;
	public Vector3 hitDirection;
	public Rigidbody rb;
	public GameObject trial;
	public ForceMode FM;
	public Vector3 startPos;
	public Vector2 touchStartPosition,touchEndPosition;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		startPos = transform.position;
	}


	void OnEnable(){
		EasyTouch.On_SwipeStart += On_SwipeStart;
		EasyTouch.On_Swipe += On_Swipe;
		EasyTouch.On_SwipeEnd += On_SwipeEnd;		
	}

	void OnDisable(){
		UnsubscribeEvent();

	}

	void OnDestroy(){
		UnsubscribeEvent();
	}

	void UnsubscribeEvent(){
		EasyTouch.On_SwipeStart -= On_SwipeStart;
		EasyTouch.On_Swipe -= On_Swipe;
		EasyTouch.On_SwipeEnd -= On_SwipeEnd;	
	}





	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.Mouse0))
//			rb.AddForce (hitDirection * forcePower, FM);


//		if (Input.touchCount > 0) {
//
//			if (Input.GetTouch (0).phase == TouchPhase.Began) {
//
//				touchStartPosition = Input.GetTouch (0).position;
//			}
//
//			else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
//
//				touchEndPosition = Input.GetTouch (0).position;
//			}
//		}

	}

	private void On_SwipeStart( Gesture gesture){
		touchStartPosition = MouseHelper.mousePosition;
		print ("start");
	}
	private void On_Swipe( Gesture gesture){
		
		Vector3 position = gesture.GetTouchToWorldPoint(5);
//		trail.transform.position = position;
		trial.transform.position = position;

	}

	private void On_SwipeEnd( Gesture gesture){

		touchEndPosition = MouseHelper.mousePosition;
		print (Vector2.Distance (touchStartPosition, touchEndPosition));

		forcePower = Vector2.Distance (touchStartPosition, touchEndPosition) / 15;

		forcePower = Mathf.Clamp (forcePower, 5, 7);

		hitDirection = new Vector3 (1-(gesture.GetSwipeOrDragAngle ()/90), 1, 1);

		rb.AddForce (hitDirection * forcePower, FM);


		Invoke ("ResetPosition", 2);
		//print ("angle" + gesture.GetSwipeOrDragAngle ());
	}

	void ResetPosition(){

		transform.position = startPos;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
}
