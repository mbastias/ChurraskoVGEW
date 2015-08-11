 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController gc;
	public GameObject Dios1;
	public GameObject Dios2;
	private float timer = 0;
	
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
		timer += Time.deltaTime;
		if (timer > 60f) {
			if(Dios1.GetComponent<LordCollider>().currentHappiness >= Dios2.GetComponent<LordCollider>().currentHappiness)
				Application.LoadLevel("WinPlayer1");
			else
				Application.LoadLevel("WinPlayer2");
		}
	}
	
}
