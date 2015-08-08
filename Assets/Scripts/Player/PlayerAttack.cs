using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject attackGameObject;
	GameObject[] slowAttacks;
	public float attackVelocity;
	int lastSpawned, newSpawn;
	int attackQuantity;
	private Animator anim;

	// Use this for initialization
	void Start () {

		lastSpawned = 0;
		newSpawn = -1;
		attackQuantity = 3;

		anim = GetComponent<Animator> ();
		anim.SetBool("isAttacking",false);

		slowAttacks = new GameObject[attackQuantity];
		for (int i=0; i<attackQuantity; i++) {

			slowAttacks[i] = Instantiate(attackGameObject,Vector3.zero, Quaternion.identity) as GameObject;
			slowAttacks[i].SetActive(false);

		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (anim.GetBool ("isAttacking"))
			anim.SetBool ("isAttacking", false);

		if (Input.GetKeyDown (KeyCode.C)) {

			anim.SetBool("isAttacking",true);
			spawnAttack();
		}
			//
	
	}

	void spawnAttack() {

		newSpawn = lastSpawned % attackQuantity;

		slowAttacks [newSpawn].SetActive (true);
		slowAttacks [newSpawn].transform.position = transform.FindChild ("Attack Point").transform.position;
		Rigidbody2D rgAttack = slowAttacks [newSpawn].GetComponent<Rigidbody2D> ();

		if (transform.localScale.x > 0) {
			rgAttack.velocity = new Vector2 (attackVelocity, 0);
			slowAttacks [newSpawn].transform.localScale = 
				new Vector3 (Mathf.Abs (slowAttacks [newSpawn].transform.localScale.x), slowAttacks [newSpawn].transform.localScale.y,slowAttacks[newSpawn].transform.localScale.z);
		}

		else {
			slowAttacks[newSpawn].transform.localScale = 
				new Vector3(-Mathf.Abs(slowAttacks[newSpawn].transform.localScale.x),slowAttacks[newSpawn].transform.localScale.y,slowAttacks[newSpawn].transform.localScale.z);
			rgAttack.velocity = new Vector2 (-attackVelocity, 0);

		}
		if (lastSpawned == 100)
			lastSpawned = 0;
		lastSpawned++;

	}
}
