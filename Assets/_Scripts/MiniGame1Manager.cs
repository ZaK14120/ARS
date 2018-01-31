using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MiniGame1Manager : MonoBehaviour {
	public Transform charPivot, cameraPivot,Ball;
	public Transform chokePoint;
	public float speed,jumpPower,charAnimTimeGap;
	float jumpTime,timeLeft, reachTime;
	float jumpLimiter=4f;
	public Ease easeType;
	bool isHit=true;
	bool isGame;
	public bool isDebug;
	public Text scoreText;
	int count=-1;

	// Use this for initialization
	void Start () {
		
		//StartGame ();

		if (isDebug) {
			HitToChar ();
			jumpLimiter=1.5f;
//			isHit = true;
			isGame = true;
		}
	}

	public void StartGame(){
		AppUIManager.instance.OpenPage (2);
		Ball.position = cameraPivot.position;
		Ball.gameObject.SetActive (true);
		scoreText.gameObject.SetActive (true);
		Ball.localScale = new Vector3 (11, 11, 11);
		isHit = true;
		HitToChar ();
		isGame = true;
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft = reachTime - Time.time;
		if (!isGame)
			return;

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (timeLeft < 1f&&!isHit) {
				HitToChar ();
				CancelInvoke ("GameOver");
				isHit = true;
			}
				
		}
	}
	int Rand;
	public void HitToChar(){
		Rand = Random.Range(1,4);
		charPivot = CharacterController2.instance.HitPoints[Rand-1];
		jumpTime = Vector3.Distance (Ball.position, charPivot.position) / speed;
		if (jumpTime < 1.5f)
			jumpTime = 1.5f;
		jumpPower = jumpTime / jumpLimiter;
		Invoke ("CharJumpAnim", jumpTime - charAnimTimeGap);
		Ball.DOJump (charPivot.position, jumpPower, 1, jumpTime, false).SetEase (easeType).OnComplete (() => {

			if (charPivot == CharacterController2.instance.HitPoints [3]) {
				Ball.DOMove(chokePoint.position,0.3f,false);
			}


			HitToCamera();
		});

		DisplayScore ();
	}

	void CharJumpAnim(){
		

		CharacterController2.instance.HitAnim (Rand);
	}

	public void HitToCamera(){
		Vector3 RandPosition = new Vector3 (Random.Range (-0.3f, 0.2f), 0, 0);
		RandPosition = Vector3.zero;
		jumpTime = Vector3.Distance (Ball.position, cameraPivot.position+RandPosition) / speed;
		if (jumpTime < 1.5f)
			jumpTime = 1.5f;
		jumpPower = jumpTime / jumpLimiter;
		Ball.DOJump (cameraPivot.position+RandPosition, jumpPower, 1, jumpTime, false).SetEase (easeType);
		reachTime = Time.time+jumpTime;
		isHit = false;

		Invoke ("GameOver", jumpTime);
	}

	public void CloseGame(){
		if (!isGame)
			return;


		CancelInvoke ("GameOver");
		isHit = true;
		isGame = false;
		count = -1;
		scoreText.gameObject.SetActive (false);
		Ball.DOScale (Vector3.zero, 0.5f).SetEase (Ease.InElastic).OnComplete (() => {
			Ball.gameObject.SetActive (false);
		});
	}

	public void GameOver(){
		if (!isGame)
			return;
		Ball.DOScale (Vector3.zero, 0.5f).SetEase (Ease.InElastic).OnComplete (() => {
			Ball.gameObject.SetActive (false);
		});
		isGame=false;
		AppUIManager.instance.OpenPage (1);
		count = -1;
		scoreText.gameObject.SetActive (false);
	}

	public void DisplayScore()
	{
		count = count + 1;
		scoreText.text = "Score:" + count.ToString ();
	}

}
