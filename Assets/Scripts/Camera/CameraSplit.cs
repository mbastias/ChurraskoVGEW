using UnityEngine;
using System.Collections;

public class CameraSplit : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	private Camera CameraObject;

	// Use this for initialization
	void Start () {
		CameraObject = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1.transform.position.x > Player2.transform.position.x) {
			Vector2 position = new Vector2(.501f, 0);
			Vector2 size = new Vector2(.499f, 1);
			CameraObject.rect = new Rect(position, size);
		} else {
			Vector2 position = new Vector2(0, 0);
			Vector2 size = new Vector2(.499f, 1);
			CameraObject.rect = new Rect(position, size);
		}
		FollowPlayer ();
	}

	void FixedUpdate(){
	}

	void FollowPlayer(){
		Vector3 CameraPosition = transform.position;
		Vector3 Player1Position = Player1.transform.position;
		Player1Position.y += 4;
		transform.position = new Vector3 (Player1Position.x, Player1Position.y, CameraPosition.z);
	}
}
