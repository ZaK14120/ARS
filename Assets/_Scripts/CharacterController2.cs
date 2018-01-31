using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour {
	public Transform[] HitPoints;
	public Animator _animator;
	public static CharacterController2 instance;
	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update () {
		
	}

//	public void HitAnim(){
//
//		_animator.SetBool ("isJump",true);
//		//_animator.SetBool ("isKick",true);
//		Invoke ("MoveToIdle", 0.1f);
//	}
//

	public void HitAnim(int Rand){

		//_animator.SetBool ("isJump",true);



		_animator.SetInteger ("JumpType", Rand);
		Invoke ("MoveToIdle", 0.1f);
	}

	public void MoveToIdle(){
		_animator.SetInteger ("JumpType", 0);
		_animator.SetInteger ("Run", 0);
		_animator.SetInteger ("Jump", 0);
		//_animator.SetBool ("isJump",false);
		//_animator.SetBool ("isKick",false);
	}

	public void RunAnim()
	{
		_animator.SetInteger ("Run", 1);
	}

	public void JumpAnim(){
		_animator.SetInteger ("Jump", 1);
		Invoke ("JumpReset", 0.5f);

	}

	public void JumpReset(){
		_animator.SetInteger ("Jump", 0);
		Game3Manager.instance.isJump = false;
	}
}
