//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class TimerComponent : MonoBehaviour {
//
//	public bool start;
//	public float time=0.0f;
//	bool isSpeedDoubled;
//	bool isSpeedTripled;
//
//	public static TimerComponent instance;
//	// Use this for initialization
//	void Awake () {
//		instance = this;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (start) 
//		{
//			time += Time.deltaTime;
//		}
//
//		if (time >= 10f && time < 30f && !isSpeedDoubled) {
//			isSpeedDoubled = true;
//			ObstacleBehaviour.instance.DoubleSpeed ();
//			isSpeedTripled = false;
//		} else if (time >= 30f && !isSpeedTripled) {
//			isSpeedDoubled = true;
//			ObstacleBehaviour.instance.TripleSpeed ();
//			isSpeedTripled = true;
//		}
//	}
//
//	public void StartTimer()
//	{
//		start = true;
//		isSpeedDoubled = false;
//	}
//
//	public void StopTimer()
//	{
//		start = false;
//
//	}
//
//
//	public void ResetTimer()
//	{
//		StopTimer ();
//		time = 0.0f;
//	}
//}
////