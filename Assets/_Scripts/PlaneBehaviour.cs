//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class PlaneBehaviour : MonoBehaviour {
//
//
//	public float planespawnInterval;
//	public GameObject pooledPlane;
//	public static PlaneBehaviour instance;
//
//	void Awake()
//	{
//		instance = this;
//	}
//
//	void Start () {
//
//		InvokeRepeating("PlaneSpawn", planespawnInterval, planespawnInterval);
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	public void PlaneSpawn()
//	{
//		pooledPlane = PlaneManager.instance.GetPlane ();
//
//		if (pooledPlane == null)
//			return;
//
//		pooledPlane.transform.position = transform.position;
//		pooledPlane.transform.rotation = transform.rotation;
//		pooledPlane.SetActive (true);
//		//pooledPlane.transform.SetParent (null);
//
//
//	}
//
//}
