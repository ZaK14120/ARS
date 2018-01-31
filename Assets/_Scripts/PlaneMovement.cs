using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

	public float moveSpeed = 12f;
	public float baseSpeed = 6f;
	public float maxSpeed;
	public bool isPooled;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//moveSpeed = baseSpeed + (maxSpeed * Time.timeSinceLevelLoad / 60f);
		if (Game3Manager.instance.isGame) {
			transform.Translate (new Vector3 (0f, 0f, -1f) * moveSpeed * Time.deltaTime, Space.Self);
		}


	


//		if (moveSpeed < 8f) {
//			SpawnPointManager.instance.interval = 3f;
//		} else if (moveSpeed >= 8f && moveSpeed < 14f) {
//			SpawnPointManager.instance.interval = 2f;
//		} else if (moveSpeed >= 14f && moveSpeed < 20f) {
//			SpawnPointManager.instance.interval = 1f;
//		} else {
//			SpawnPointManager.instance.interval = 0.5f;
//		}
	}
}
