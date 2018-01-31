using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HedgehogTeam.EasyTouch;
using DG.Tweening;

public class SwipeTest : MonoBehaviour {

	public GameObject trail;
	public Transform ballReset;
	public Rigidbody Ball;
	public Transform GoalPost;
	public float HitPower, HitTime;
	public float HitLimiter=1.5f;
	public float ballSpeed;
	public Ease easeType;
	float rads;
//	public Text swipeText;

	void Start(){
		Ball = GetComponent<Rigidbody> ();
	}

	// Subscribe to events
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


	// At the swipe beginning 
	private void On_SwipeStart( Gesture gesture){


	}

	// During the swipe
	private void On_Swipe(Gesture gesture){

		if (gesture.swipe == EasyTouch.SwipeDirection.Up) {

//			Ball.AddForce (transform.forward * ballSpeed, ForceMode.Impulse);
		//	Ball.AddForce (transform.up * ballSpeed, ForceMode.force);
		}
//		if (gesture.swipeLength <= 1f) {
//
//			Ball.AddForce (transform.forward * ballSpeed, ForceMode.Acceleration);
//
//		} else if (gesture.swipeLength > 1f && gesture.swipeLength <= 3f) {
//
//			Ball.AddForce (transform.forward * ballSpeed * 2f, ForceMode.Acceleration);
//
//		} else if (gesture.swipeLength > 3f) {
//
//			Ball.AddForce (transform.forward * ballSpeed * 5f, ForceMode.Acceleration);
//
//		} 
//		// the world coordinate from touch for z=5
//		Vector3 position = gesture.GetTouchToWorldPoint(5);
//		trail.transform.position = position;
//
//		Vector3 targetDir = GoalPost.position - transform.position;
//		float angle = Vector3.Angle(targetDir, transform.forward);
//
//		transform.position = Vector3.MoveTowards(transform.position, GoalPost.position, ballSpeed * Time.deltaTime);


//		HitTime = Vector3.Distance (Ball.position, GoalPost.position) / ballSpeed;
//		HitPower = HitTime / HitLimiter;

//		if (gesture.swipe == EasyTouch.SwipeDirection.Up) {
//			
////					isSwiped = true;
//
//				
//			Ball.DOJump (GoalPost, HitPower, 1, HitTime, false).SetEase (easeType).OnComplete (() => {
//			//Ball.DOJump (GoalPost, HitPower, 1, HitTime, false).SetEase (easeType).OnComplete(()=>{
//			Ball.position = ballReset.position;
//			//			isGoalHit = true;
//			//			isBallReset = true;
//			
//			});
//		}
			
	}

	// At the swipe end 
	private void On_SwipeEnd(Gesture gesture){

		// Get the swipe angle
		float angle = gesture.GetSwipeOrDragAngle();
		rads = angle * Mathf.PI / 180;

//		swipeText.text = "Last swipe : " + gesture.swipe.ToString() + " /  vector : " + gesture.swipeVector.normalized + " / angle : " + angles.ToString("f2");
	}

}
