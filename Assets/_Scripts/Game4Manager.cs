using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HedgehogTeam.EasyTouch;

public class Game4Manager : MonoBehaviour {

	//public Transform Dog;
	public Camera ARCam;
//	public Transform Ball;
//	public Transform ballReset;
	public float ballSpeed, HitPower;
	float HitLimiter=1.5f;
	float HitTime;
	public Transform[] Targets;
	public Transform goalPost;
	float activeIndex;
	Vector3 goal;
	int count = -1;
	public Text scoreText;

	public float forcePower;
	public Vector3 hitDirection;
	public Rigidbody rb;
	public GameObject trial;
	public ForceMode FM;
	public Transform startPos;
	public Vector2 touchStartPosition,touchEndPosition;

//	bool isBallReset=true;
	public bool isTargetHit;
	bool isGame;
	bool isSwiped;

	public static Game4Manager _instance;

	void Awake()
	{
		_instance = this;
	}

	void Start () {
		
//		Ball.position = ballReset.position;
//		Ball.gameObject.SetActive (true);

		//rb = GetComponent<Rigidbody> ();
		//rb.GetComponent<Rigidbody>();
		startPos.position = rb.transform.position;

		ShowRandomTarget ();
		DisplayScore ();


	}

	void Update () {

//		if (!isGame)
//			return;

//		if (Input.GetKeyDown (KeyCode.Mouse0)) {
//
//			Ray ray = ARCam.ScreenPointToRay (Input.mousePosition);
//			RaycastHit hit;
//
//			if(Physics.Raycast(ray, out hit, 1500)){
//				BallHit(hit.point);
//				isTargetHit = false;
//
////				On_Swipe (Gesture swiped);
//
//				//print (hit.collider.name);
//			}
//		}

	}

//	public void BallHit(Vector3 goal){
//
////		if (!isBallReset)
////			return;
//
//		HitTime = Vector3.Distance (Ball.position, goal) / ballSpeed;
//		HitPower = HitTime / HitLimiter;
//
//		//Ball.DOMove (goal, HitTime, false).SetEase (balleaseType).OnComplete (() => {
//		Ball.DOJump (goal, HitPower, 1, HitTime, false).SetEase (balleaseType).OnComplete(()=>{
////			playerPos ();
//			Ball.position = ballReset.position;
////			isBallReset = true;
//
//			if(isTargetHit){
//
//				count = count +1;
//				DisplayScore();
//
//			}
//		});
//	}
		

//	public void playerPos()
//	{
//		transform.position = new Vector3 (Random.Range (-0.89f,0.95f), 1f, Random.Range (-9.16f,-6.64f));
//	}

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

		forcePower = Vector2.Distance (touchStartPosition, touchEndPosition) / 30;

		forcePower = Mathf.Clamp (forcePower, 7, 10);

		hitDirection = new Vector3 (1-(gesture.GetSwipeOrDragAngle ()/90), 1, 1);

		rb.AddForce (hitDirection * forcePower, FM);

		Invoke ("ResetPosition", 2f);
		//print ("angle" + gesture.GetSwipeOrDragAngle ());
	}

	public void ResetPosition(){

		rb.transform.position = startPos.position;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		isTargetHit = false;
	}

	public void ShowRandomTarget(){
		HideAllTargets ();
		int Rand;
//		for (int i = 0; i < Random.Range (0, Targets.Length); i++) {
		Rand = Random.Range (0, Targets.Length);
		Targets [Rand].gameObject.SetActive (true);
		isTargetHit = true;

//		}
	}


	public void HideAllTargets(){
		foreach (Transform T in Targets) {
			T.gameObject.SetActive (false);

		}
	}

	public void DisplayScore(){

		//isTargetHit = true;

		if(isTargetHit){

			count = count +1;
			isTargetHit = false;
			//DisplayScore();


		}

		scoreText.text = "Score: " + count.ToString ();


	}
}
