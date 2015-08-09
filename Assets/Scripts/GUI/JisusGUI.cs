using UnityEngine;
using System.Collections;

public class JisusGUI : MonoBehaviour {

	private float fromx = -7f;
	private float tox = -1f;
	private bool direction;

	// Use this for initialization
	void Start () {
		direction = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (direction && transform.position.x < tox) {
			Vector3 actual = transform.position;
			actual.x += .1f;
			transform.localScale = new Vector3(-.5f, .5f, 1);
			transform.position = actual;
		} else {
			direction = false;
		}
		if (!direction && transform.position.x > fromx) {
			Vector3 actual = transform.position;
			actual.x -= .1f;
			transform.localScale = new Vector3(.5f, .5f, 1);
			transform.position = actual;
		} else {
			direction = true;
		}
	}
}
