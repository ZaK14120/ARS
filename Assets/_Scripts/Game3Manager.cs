using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HedgehogTeam.EasyTouch;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Game3Manager : MonoBehaviour {

//	public float slideSpeed;
//	private float step;
	private Transform startPoint;
	public Transform[] movePoints;
	public Vector3[] movePositions;
	public Transform ObsSpawner;
//	public Transform BoyMesh;
	public bool isGame;
	public bool isJump;
	bool isSwiped;
	public bool isDebug;
	public static Game3Manager instance;
	public Text scoreText3;
	int count = -100;
	public GameObject GameOverPanel;



	void Awake()
	{
		instance = this;
	}


	void Start(){
		if (isDebug) {
			//AppUIManager.instance.OpenPage (2);
			//ObstacleSpawner.instance.Spawn();
			PlayerEnergy.instance.startingTime = Time.time;
			GameOverPanel.gameObject.SetActive(false);
			CharacterController2.instance.RunAnim ();

			for (int i = 0; i < movePoints.Length; i++) {
				movePoints [i].gameObject.SetActive (true);
			}
			startPoint = movePoints [1];
//			TimerComponent.instance.StartTimer ();
			isGame = true;
			isSwiped = false;
			CalcScore ();

			for (int i = 0; i < 3; i++)
				movePositions [i] = movePoints [i].position;


		}
	}


	void Update(){
		//step = slideSpeed * Time.deltaTime;
//		CalcScore();


	}

//	public void StartGame3()
//	{
//		AppUIManager.instance.OpenPage (2);
//		//ObsSpawner.gameObject.SetActive (true);
//		//ObstacleSpawner.instance.Spawn();
//		CharacterController2.instance.RunAnim ();
////		BoyMesh.transform.Rotate(new Vector3(0,180,0));
////		scoreText3.gameObject.SetActive (true);
//
//		for (int i = 0; i < movePoints.Length; i++) {
//			movePoints [i].gameObject.SetActive (true);
//		}
//
////		movePointparent.transform.position = transform.position;
////		movePointparent.gameObject.SetActive (true);
//		startPoint = movePoints [1];
////		movePoints [0].position = transform.position + new Vector3 (-0.2f, 0f, 0f);
////		movePoints [2].position = transform.position + new Vector3 (0.2f, 0f, 0f);
////		ObsSpawner.position = transform.position + new Vector3 (0f, 0f, 8f);
//		TimerComponent.instance.StartTimer ();
//		isGame = true;
//		isSwiped = false;
//
//		for (int i = 0; i < 3; i++) {
//			movePositions [i] = movePoints [i].position;
//		}
//		//startPoint.position = movePositions [1];
//	}
//		

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
		if (isSwiped||!isGame)
			return;


		//print ("Swipe detected" + gesture.swipe.ToString());

		//if(gesture.swipe == SwipeDirection
		if (gesture.swipe == EasyTouch.SwipeDirection.Left) {
			//print ("left");
			//transform.Translate (Vector3.left * slideSpeed * Time.deltaTime);
			isSwiped = true;
			if (startPoint == movePoints [1]) {
				//transform.position = Vector3.MoveTowards (movePoints [1].transform.position, movePoints [0].transform.position, slideSpeed);
				transform.DOMove (movePositions [0], 0.2f, false).OnComplete (() => {
					startPoint = movePoints [0];
				});
			} else if (startPoint == movePoints [2]) {
				//transform.position = Vector3.MoveTowards (movePoints [2].transform.position, movePoints [1].transform.position, slideSpeed);
				transform.DOMove(movePositions [1],0.2f,false).OnComplete (() => {
					startPoint = movePoints [1];
				});
			//	startPoint = movePoints [1];
			} 

		}

		if (gesture.swipe == EasyTouch.SwipeDirection.Right) {
			//print ("right");
			//transform.Translate (Vector3.right * slideSpeed * Time.deltaTime);
			//transform.position = Vector3.Lerp(new Vector3(0f,1f,-5.75f), new Vector3(1.5f,1f,-5.75f), lerpTime);
			isSwiped = true;
			if (startPoint == movePoints [1]) {
				//transform.position = Vector3.MoveTowards (movePoints [1].transform.position, movePoints [2].transform.position, slideSpeed);
				transform.DOMove(movePositions [2],0.2f,false).OnComplete (() => {
					startPoint = movePoints [2];
				});
			} else if (startPoint == movePoints [0]) {
				//transform.position = Vector3.MoveTowards (movePoints [0].transform.position, movePoints [1].transform.position, slideSpeed);
				transform.DOMove(movePositions [1],0.2f,false).OnComplete (() => {
					startPoint = movePoints [1];
				});
			} 

		}

		if (gesture.swipe == EasyTouch.SwipeDirection.Up) {
			//print (gesture.swipeLength);
//			if(gesture.swipeLength>
			isSwiped = true;
			CharacterController2.instance.JumpAnim ();
			isJump = true;

		}

	}

	// At the swipe end 
	private void On_SwipeEnd(Gesture gesture){
		isSwiped = false;

	
	}


	public void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "ScoreCol") {
			CalcScore ();
		}
	}

	public void CloseGame3()
	{
//		if (!isGame)
//			return;




		//ObstacleSpawner.instance.GameOver ();
		//SpawnPointManager.instance.GameOver();
		//transform.position = movePositions[1];
		transform.DOMove(movePositions[1], 0.2f, false);
//		scoreText3.gameObject.SetActive (false);
//		GameObject[] objs = GameObject.FindGameObjectsWithTag("PlayerDummy");
//		foreach (GameObject obj in objs) {
//			Destroy (obj);
//		}
//		BoyMesh.transform.Rotate(new Vector3(0,180,0));

		for (int i = 0; i < movePoints.Length; i++) {
			movePoints [i].gameObject.SetActive (false);
		}

		isGame = false;
		isSwiped = true;
		CharacterController2.instance.MoveToIdle ();
		SceneManager.LoadScene ("ARScene");
//		movePointparent.gameObject.SetActive (false);


	}
	GameObject[] objs ;
	public void GameOver3()
	{
		//ObstacleSpawner.instance.GameOver ();
		//transform.position = movePositions[1];
//		SceneManager.LoadScene("ARScene");

		transform.DOMove(movePositions[1], 0.2f, false);
//		BoyMesh.transform.Rotate(new Vector3(0,180,0));
//		scoreText3.gameObject.SetActive (false);

		for (int i = 0; i < movePoints.Length; i++) {
			movePoints [i].gameObject.SetActive (false);
		}

		isGame = false;
		isSwiped = true;
		CharacterController2.instance.MoveToIdle ();
		GameOverPanel.gameObject.SetActive(true);
		PlayerEnergy.instance.EnergyBar.gameObject.SetActive(false);
		//PlayerEnergy.instance.EnergyBar.value = 1f;
		Energy_GAFcontrol.instance.Clip.gameObject.SetActive (false);
		Energy_GAFcontrol.instance.RenewEnergy ();
		//scoreText3.gameObject.SetActive (false);

		objs = GameObject.FindGameObjectsWithTag("EnergyPack");
		foreach (GameObject obj in objs) {
			obj.gameObject.SetActive (false);
		}
		
		
		//AppUIManager.instance.OpenPage (0);
	}

	public void CalcScore()
	{
//		if (transform.position.z + ObstacleSpawner.instance.Clone.gameObject.transform.position.z == 1f) {
		count = count + 100;
		scoreText3.text = " " + count.ToString ();

		//StartCoroutine (MoveScore (100));
//		} else
//			return;
	}

//	IEnumerator MoveScore(int target){
//		int temp = count + target;
//		while (temp > count) {
//			count++;
//			yield return new WaitForEndOfFrame();
//		}
//		scoreText3.text = " " + count.ToString ();
//	}


	public void SceneSwitch()
	{
//		Application.load
		SceneManager.LoadScene("MG3_var");
	}

	public void SceneSwitch(int id)
	{
		//		Application.load
		SceneManager.LoadScene(id);
	}

	public void ReplayGame()
	{
		
		CharacterController2.instance.RunAnim ();
		//SpawnPointManager.instance.ReplayGame ();
		PlayerEnergy.instance.EnergyBar.gameObject.SetActive(true);
		Energy_GAFcontrol.instance.Clip.gameObject.SetActive (true);
		scoreText3.gameObject.SetActive (true);
		PlayerEnergy.instance.EnergyBar.value = 1f;
		PlayerEnergy.instance.startingTime = Time.time;

		foreach (GameObject obj in objs) {
			obj.gameObject.SetActive (true);
		}
		for (int i = 0; i < movePoints.Length; i++) {
			movePoints [i].gameObject.SetActive (true);
		}
		startPoint = movePoints [1];
		//			TimerComponent.instance.StartTimer ();
		isGame = true;
		isSwiped = false;
		count = -100;
		CalcScore ();

		for (int i = 0; i < 3; i++) {
			movePositions [i] = movePoints [i].position;
		}
		GameOverPanel.gameObject.SetActive(false);

		SceneManager.LoadScene ("MG3_var");



	}
}
