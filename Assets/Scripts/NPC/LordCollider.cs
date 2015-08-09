﻿using UnityEngine;
using System.Collections;

public class LordCollider : MonoBehaviour {

	public AudioSource Bramido;

	void Start(){
		Bramido = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.gameObject.CompareTag("Tribute")) {

			Destroy(collider.gameObject);
			Debug.Log ("FEDEASTE A :" + gameObject.name);
			Bramido.Play();
		}
	}
}