using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Game2Manager : MonoBehaviour {
	public Camera ARCam;
	public Transform Ball,ballReset, Target;
	public float ballSpeed, timerLeft;
	bool isBallReset=true;
	bool isGoalHit;
	bool isGame;
	public Ease balleaseType;
	public List<TrainingPostBehaviour> TrainingPosts;
//	int count=0;
//	public Text scoreText, timerText;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
//		timerLeft = timerLeft - Time.deltaTime;
//		timerText.text = "Time left: " + timerLeft.ToString();


		if (!isGame)
			return;
//
//		if (timerLeft == 0f) {
//			GameOver2();
//			count = 0;
//			DisplayScore ();
//			timerLeft = 20f;

//		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			Ray ray = ARCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1500)) {
					//Debug.DrawLine (ray.origin, hit.point);
				HitBall(hit.point);
				if (hit.collider.tag == "GoalPost"&&hit.collider.GetComponentInParent<TrainingPostBehaviour>().isActive)
					isGoalHit = true;
				
				print (hit.collider.name);
			}
		}
	}

	public void StartGame2(){
		AppUIManager.instance.OpenPage (2);
		Ball.position = ballReset.position;
		Ball.gameObject.SetActive (true);

//		foreach (List<TrainingPostBehaviour> tpost in TrainingPosts)
//			tpost.gameObject.SetActive (true);
		Target.transform.position = transform.position;
		Target.gameObject.SetActive(true);
		isGame = true;
//		DisplayScore ();
		AssignTarget ();


	}

	public void HitBall(Vector3 target){
		if (!isBallReset)
			return;

		isBallReset=false;
		float hitTime = Vector3.Distance (Ball.position, target) / ballSpeed;
		transform.LookAt (target);
		Ball.DOMove (target,hitTime,false).SetEase (balleaseType).OnComplete (() => {
			Ball.position = ballReset.position;
			isBallReset=true;


			if(isGoalHit){
//				count = count +1;
//				DisplayScore();
				AssignTarget();
			}
		});
	}

	public void AssignTarget(){
		isGoalHit = false;

		foreach (TrainingPostBehaviour TP in TrainingPosts)
			TP.ResetSelection ();

		int Rand = Random.Range (0, TrainingPosts.Count);

		TrainingPosts [Rand].SelectPost ();

	}

//	public void DisplayScore(){
//		scoreText.text = "Score: " + count.ToString ();

//	}

	public void CloseGame2(){

		if (!isGame)
			return;
		
		Ball.gameObject.SetActive (false);
		Target.gameObject.SetActive(false);
//		CancelInvoke ("GameOver2");
		isGoalHit = false;
		isGame = false;

	}

//	public void GameOver2(){
//
//		if (!isGame)
//			return;
//
//		Ball.gameObject.SetActive (false);
//		Target.gameObject.SetActive(false);
//		isGame = false;
//		AppUIManager.instance.OpenPage (1);
//	}

}
