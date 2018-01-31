using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePoint : MonoBehaviour {
	public List<GameObject> ObstacleType;
	public GameObject selectedObstacle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Assign(int type){
		Clear ();

		selectedObstacle = Instantiate (ObstacleType [type], transform);


	}

	public void Clear(){
		if (selectedObstacle)
			Destroy (selectedObstacle);
	}


}
