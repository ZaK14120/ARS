using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

	public float moveSpeed;
	public static float baseSpeed = 6f;
//	public float acceleration;
	public float maxSpeed;
//	public float speedMultiplier;
	public static ObstacleBehaviour instance;
	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start () {
		
	//	Destroy ();
	}
	
	// Update is called once per frame
	void Update () {

//		moveSpeed = baseSpeed + (maxSpeed * Time.timeSinceLevelLoad / 60f);
//		transform.Translate (new Vector3 (0f, 0f, -1f) * moveSpeed *Time.deltaTime , Space.Self);
//
//		if (moveSpeed < 8f) {
//			//ObstacleSpawner.instance.interval = 3f;
//			SpawnPointManager.instance.interval = 3f;
//		} else if (moveSpeed >= 8f && moveSpeed < 14f) {
//			//ObstacleSpawner.instance.interval = 2f;
//			SpawnPointManager.instance.interval = 2f;
//		} else if (moveSpeed >= 14f && moveSpeed < 20f) {
//			//ObstacleSpawner.instance.interval = 1f;
//			SpawnPointManager.instance.interval = 1f;
//		} else {
//			//ObstacleSpawner.instance.interval = 0.5f;
//			SpawnPointManager.instance.interval = 0.5f;
//		}


	}
	GameObject[] objs;
	public void OnTriggerEnter(Collider col){

		if (tag == "JumpHurdle" && Game3Manager.instance.isJump)
			return;

		if (col.tag == "Dog") {
			
				Game3Manager.instance.GameOver3 ();
				CharacterController2.instance.MoveToIdle ();
				objs = GameObject.FindGameObjectsWithTag ("PlayerDummy");
				foreach (GameObject obj in objs)
					obj.gameObject.SetActive (true);
			} 
			//ObstacleSpawner.instance.GameOver ();
			//SpawnPointManager.instance.GameOver();

//			moveSpeed = 4f;
//			ObstacleSpawner.instance.interval = 3f;
			//Destroy (gameObject);


	}



	public void Destroy(){
		Destroy (gameObject, 15f);
	}

//	public void DoubleSpeed(){
//		moveSpeed = moveSpeed + speedMultiplier;
//		ObstacleSpawner.instance.interval = (float)ObstacleSpawner.instance.interval / (float)speedMultiplier;
//	}
//
//	public void TripleSpeed()
//	{
//		moveSpeed = moveSpeed + (speedMultiplier * 2f);
////		ObstacleSpawner.instance.interval = (float)ObstacleSpawner.instance.interval / (float)speedMultiplier;
//	}
}
