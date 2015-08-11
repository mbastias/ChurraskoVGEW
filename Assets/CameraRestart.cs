using UnityEngine;
using System.Collections;

public class CameraRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame(){
		Application.LoadLevel ("LevelFinal1");
	}
}
