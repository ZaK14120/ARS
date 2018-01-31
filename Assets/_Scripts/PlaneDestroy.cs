using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDestroy : MonoBehaviour {
	public bool isFirst;
	// Use this for initialization
	void Start () {
		
	}
	public bool isPooled;
	// Update is called once per frame
	void Update () {
		if (transform.position.z < -135 && !isPooled && Game3Manager.instance.isGame) {
			PlaneManager.instance.SpawnPlane ();
			isPooled = true;
		}
	}


}
