using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour {

	public List<Transform> SpawnPoints;
	public GameObject[] Obstacles;
	public GameObject Obstacle;
	public float interval;
	public float waitTime;
	public Transform spawnPos;
	public Transform GroundParent;
	GameObject Clone;


	public static SpawnPointManager instance;


	void Awake()
	{
		instance = this;
	}


	void Start () {
		StartCoroutine (ChangeObstacle ());
		SelectSpawnPoint ();
		//Spawn ();
		Clone = Instantiate (Obstacle, spawnPos);
		SelectSpawnPoint ();
		Clone.transform.SetParent (null);
		Clone.transform.SetParent (GroundParent);
		Invoke ("Spawn", interval);
	}

	void Update () {
		
	}

	public void SelectSpawnPoint()
	{
		int index = Random.Range (0, SpawnPoints.Count);
		spawnPos = SpawnPoints [index];

	}

	public void Spawn()
	{
		Clone = Instantiate (Obstacle, spawnPos);
//		Clone.transform.localPosition = new Vector3 (0f, 0f, 0f);
//		Clone.transform.localRotation = Quaternion.identity;
		SelectSpawnPoint ();
		Clone.transform.SetParent (null);
		//GroundParent = PlaneBehaviour.instance.pooledPlane.transform;
		//Clone.transform.SetParent (GroundParent);

		Invoke ("Spawn", interval);
	}

	IEnumerator ChangeObstacle()
	{
		for (int i = 0; i < 1000; i++) {
			int rand = Random.Range (0, 2);
			Obstacle = Obstacles [rand];
			yield return new WaitForSeconds (waitTime);
		}
	}

	public void GameOver()
	{
		CancelInvoke ();
		StopCoroutine (ChangeObstacle ());
	}
	public void ReplayGame()
	{
		StartCoroutine (ChangeObstacle ());
		SelectSpawnPoint ();
		//Clone.transform.SetParent (spawnPos);
		Spawn ();
	}
}
