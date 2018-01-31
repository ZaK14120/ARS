using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDetection : MonoBehaviour {
	public GameObject FindingSquare,ScanManager;
	public GameObject SpawnObject;
	bool isSpawned;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			
		}


	}

	public void Summon(){
		if (!isSpawned&&FindingSquare.activeSelf) {
			SpawnObject.SetActive (true);
			SpawnObject.transform.position = FindingSquare.transform.position;
			SpawnObject.transform.LookAt(Camera.main.transform);
			SpawnObject.transform.rotation = Quaternion.Euler (0, SpawnObject.transform.rotation.eulerAngles.y, 0);
			ScanManager.SetActive (false);
			AppUIManager.instance.OpenPage (1);
			isSpawned = true;
		} 
	}

	public void ResetAR(){
		ScanManager.SetActive (true);
		SpawnObject.SetActive (false);
		isSpawned = false;
		AppUIManager.instance.OpenPage (0);
	}
}
