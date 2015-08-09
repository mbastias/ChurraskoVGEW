 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController gc;
	
	
	void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		if (gc == null) {
			DontDestroyOnLoad (gameObject);
			gc = this;
		} else if (gc != this) {
			Destroy (gameObject);
		}
		
		
	}
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
