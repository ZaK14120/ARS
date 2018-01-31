using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingPostBehaviour : MonoBehaviour {
	public MeshRenderer Post;
	public bool isActive;
	public Material selectedMat,normalMat;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectPost(){
		Post.material = selectedMat;
		isActive = true;
		//Post.tag = "ActiveGoalPost";
	}

	public void ResetSelection(){
		Post.material = normalMat;
		isActive = false;
		//Post.tag = "GoalPost";
	}


}
