using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoozyUI;
using UnityEngine.SceneManagement;

public class AppUIManager : MonoBehaviour {
	public UIElement[] Pages;
	public GameObject[] Dogs;
	// Use this for initialization
	public static AppUIManager instance;
	bool isRecording=false;
	public UIButton[] Button;
	public UIButton[] GameListButton;
	public UIButton[] RhymeListButton;
//	public UIButton[] UpgradeButton;
//	public UIButton[] FoodButton;
	public GameObject RhymeText;

	void Awake(){
		instance = this;
	}

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenPage(int pageNo){
		ClosePages ();
		Pages [pageNo].gameObject.SetActive (true);
		Pages [pageNo].Show (false);
	}

	void ClosePages(){
		foreach (UIElement ue in Pages) {
			ue.gameObject.SetActive (false);
		}
	}

	public void PlayRhymes(){
		
		Dogs [1].SetActive (true);


		Record ();
	}

	public void PlayIdle(){
		Dogs [0].SetActive (true);
		Dogs [0].GetComponent<MiniGame1Manager> ().CloseGame ();
		//Dogs [0].GetComponent<Game2Manager> ().CloseGame2 ();
		//Dogs [0].GetComponent<Game3Manager> ().CloseGame3 ();
		Dogs [1].SetActive (false);

		OpenPage (1);

		StopRecord ();
	}

	public void Record(){
		
		if (!Everyplay.IsReadyForRecording ())
			return;

		//Button [0].gameObject.SetActive (false);
		Button [1].gameObject.SetActive (true);
		if (!Everyplay.IsRecording()) {
			Everyplay.StartRecording ();
			isRecording = true;
		}

	}


	public void StopRecord(){
		if (!isRecording)
			return;
		
		isRecording = false;
		Everyplay.StopRecording ();
		Button [0].gameObject.SetActive (true);
		Everyplay.ShowSharingModal ();
		Button [1].gameObject.SetActive (false);

	}

	public void InitializeRhymes()
	{
		OpenPage (2);
		Button [0].gameObject.SetActive (false);
		Dogs [0].SetActive (false);
		RhymeText.gameObject.SetActive (true);
		Invoke ("RhymeInfoText", 5f);
		Invoke ("PlayRhymes", 5f);
	}

	public void RhymeInfoText()
	{
		RhymeText.gameObject.SetActive (false);
	}
}
