using UnityEngine;
using System.Collections;

public class SeaBehavior : MonoBehaviour {

	private float movementx;
	private float speedx;
	private float maxdifferencex;
	private bool directionx;
	private float movementy;
	private float speedy;
	private float maxdifferencey;
	private bool directiony;

	// Use this for initialization
	void Start () {
		movementx = 0;
		speedx = .005f;
		maxdifferencex = 1f;
		movementy = 0;
		speedy = .001f;
		maxdifferencey = .05f;
		directionx = true;
		directiony = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (directionx && movementx > maxdifferencex) {
			directionx = false;
		} else if (!directionx && movementx < -maxdifferencex) {
			directionx = true;
		}

		if (directiony && movementy > maxdifferencey) {
			directiony = false;
		} else if (!directiony && movementy < -maxdifferencey) {
			directiony = true;
		}
	}

	void FixedUpdate(){
		if (directionx) {
			front ();
		} else {
			back ();
		}

		if (directiony) {
			up ();
		} else {
			bottom ();
		}
	}

	void up(){
		Vector2 actual = transform.position;
		movementy += speedy;
		actual.y += speedy;
		transform.position = actual;
	}

	void bottom(){
		Vector2 actual = transform.position;
		movementy -= speedy;
		actual.y -= speedy;
		transform.position = actual;
	}

	void front(){
		Vector2 actual = transform.position;
		movementx += speedx;
		actual.x += speedx;
		transform.position = actual;
	}

	void back(){
		Vector2 actual = transform.position;
		movementx -= speedx;
		actual.x -= speedx;
		transform.position = actual;
	}
}
