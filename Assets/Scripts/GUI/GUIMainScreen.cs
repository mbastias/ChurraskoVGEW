using UnityEngine;
using System.Collections;

public class GUIMainScreen : MonoBehaviour {
	public void Play(string buttonID){
		Application.LoadLevel ("LevelFinal1");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
