using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject[] Obstacles;
	//public GameObject Obstacle2;
	public GameObject Obstacle;
	public float waitTime;
	public GameObject Clone;
	public static ObstacleSpawner instance;
	public float interval;

//	public List<GameObject> Obstacle;


	void Awake () {
		instance = this;
	}

	void Start () {
		StartCoroutine(ChangeObstacle());
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {

			

	}

	public void Spawn(){
		//Clone = Instantiate (Obstacle, new Vector3 (Random.Range (-2f, 2f), transform.position.y, transform.position.z), transform.rotation);
		Clone = Instantiate (Obstacle, transform);
		Clone.transform.localPosition = new Vector3 (Random.Range (-2f, 2f), Obstacle.transform.position.y,0);
		Clone.transform.localRotation = Quaternion.identity;
		//Clone.transform.localScale = Vector3.one * 2.5f;
		Clone.transform.SetParent(null);
		//StartCoroutine(ChangeObstacle());

		Invoke ("Spawn", interval);
	}



	public void GameOver(){
		CancelInvoke ();
		StopCoroutine (ChangeObstacle());
		//Destroy (gameObject);
	}

//	public void OnTriggerEnter(Collider col){
//		if (col.tag == "Dog") {
//			
//			Destroy (gameObject);
//			//Destroy(GameObject.FindWithTag("PlayerDummy"));
//
//		}
//	}

	IEnumerator ChangeObstacle()
	{
		for (int i = 0; i < 1000; i++) {
			int rand = Random.Range (0, 3);
			Obstacle = Obstacles [rand];
			yield return new WaitForSeconds (waitTime);
		}
//		Obstacle = Obstacle2;
//		yield return new WaitForSeconds (waitTime);
	}
}
