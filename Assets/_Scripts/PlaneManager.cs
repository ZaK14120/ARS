using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour {

	public GameObject PlaneModel,planeParent;
	public int pooledAmount = 10;
	public float planeDistance;
	public List<GameObject> AvailablePlanes,CurrentPlanes;

	public static PlaneManager instance;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
//		Planes = new List<GameObject> ();
//		for (int i = 0; i < pooledAmount; i++) {
//			GameObject obj = (GameObject)Instantiate (PlaneModel);
//			obj.SetActive (false);
//			Planes.Add (obj);
//
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnPlane(){
		CurrentPlanes [0].transform.SetParent (transform);
		CurrentPlanes [0].SetActive (false);
		AvailablePlanes.Add (CurrentPlanes [0]);
		CurrentPlanes.RemoveAt (0);
		int i = Random.Range (0, AvailablePlanes.Count);
		CurrentPlanes.Add (AvailablePlanes [i]);
		AvailablePlanes.RemoveAt (i);


		CurrentPlanes [2].GetComponent<PlaneDestroy> ().isPooled = false;
		CurrentPlanes [2].transform.parent = planeParent.transform;
		CurrentPlanes [2].transform.localPosition = CurrentPlanes [1].transform.localPosition + new Vector3 (0, 0, planeDistance);
		CurrentPlanes [2].SetActive (true);

	}

	public GameObject GetPlane()
	{
//		for (int i = 0; i < Planes.Count; i++) {
//			if (!Planes [i].activeInHierarchy) {
//				return Planes [i];
//			} 
//		}
//
	return null;
	}
}
