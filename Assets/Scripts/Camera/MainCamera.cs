using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	private Camera CameraComponent;

	// Use this for initialization
	void Start () {
		CameraComponent = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (Player1.transform.position, Player2.transform.position) < 15f) {
			CameraComponent.depth = 3;
			Vector3 position = transform.position;
			position.z = -10;
			transform.position = position;
		} else {
			CameraComponent.depth = 0;
			Vector3 position = transform.position;
			position.z = 0;
			transform.position = position;
		}
		FollowPlayers ();
	}

	void FollowPlayers(){
		Vector3 CameraPosition = transform.position;
		Vector3 Player1Position1 = Player1.transform.position;
		Vector3 Player1Position2 = Player2.transform.position;
		Vector3 NewPosition = Vector3.zero;

		if (Player1Position1.y > Player1Position2.y) {
			NewPosition.y = (Player1Position1.y + Player1Position2.y) / 2f;
		} else {
			NewPosition.y = (Player1Position2.y + Player1Position1.y) / 2f;
		}

		if (Player1Position1.x > Player1Position2.x) {
			NewPosition.x = (Player1Position1.x + Player1Position2.x) / 2f;
		} else {
			NewPosition.x = (Player1Position2.x + Player1Position1.x) / 2f;
		}

		NewPosition.z = CameraPosition.z;
		NewPosition.y += 2f;

		Debug.Log (NewPosition);

		transform.position = NewPosition;
	}
}
