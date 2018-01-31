using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneProperties : MonoBehaviour {
	public ObstacleContainer _ObstacleContainer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		AssignObstacles ();
	}


	public void AssignObstacles(){
		foreach (Row r in _ObstacleContainer.Rows) {
			foreach (ObstaclePoint OP in r.ObstaclePoints) {
				OP.Clear ();
			}
			r.ObstaclePoints [Random.Range (0, 3)].Assign (Random.Range(0,3));
		}
	}

	[System.Serializable]
	public class Row{
		public List<ObstaclePoint> ObstaclePoints = new List<ObstaclePoint>();

	}

	[System.Serializable]
	public class ObstacleContainer{
		public List<Row> Rows = new List<Row>();

	}
}
