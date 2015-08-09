using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

	private Rigidbody2D rg;
	public Transform lineStart,lineEndLeft,lineEndRight;
	public Transform meleeStart, meleeEnd;
	public Transform meleeStart2, meleeEnd2;
	public float MoveSpeed;
	private float direction;
	private float movement;
	public float jumpHeight;
	public bool isGrounded;
	private Animator anim;
	public float meleeAttackSpeed = 0.5F;
	private float nextAttackSpeed = 0.0F;
	private bool hasTribute;
	private Collider2D tribute;
	private Vector3 spawnPoint;
	private Camera cam1;

	// Use this for initialization
	void Awake () {
	
		rg = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		isGrounded = false;
		hasTribute = false;
		spawnPoint = transform.position;
		cam1 = GameObject.Find ("Camera Player1").GetComponent<Camera> ();
	
	}
	
	// Update is called once per frame
	void Update()
	{
		Raycast();

		if(Input.GetButtonDown("JumpP1"))
		{
			jump();
		}

		if (Input.GetButtonDown ("MeleeP1")) {

			if(!hasTribute) grabTribute();
			else dropTribute();

			if(Time.time > nextAttackSpeed) {

				nextAttackSpeed = Time.time + meleeAttackSpeed;

				if(!hasTribute) {
					meleeAttack();
					anim.SetBool("isAttacking",true);
				}
			}
		}
	}
	
	void FixedUpdate () 
	{

		if (rg.velocity.x > 0) 
			transform.localScale = new Vector3 (Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
		
		else if (rg.velocity.x < 0)
			transform.localScale = new Vector3 (-Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);

		if (rg.velocity.x != 0) {
			anim.SetBool ("isWalking", true);

		} else {
			anim.SetBool ("isWalking", false);
		}

		if (rg.position.y < -3f) {
			//cam1 = GameObject.Find ("Camera Player1").GetComponent<Camera> ();
			cam1.clearFlags = CameraClearFlags.SolidColor;
			cam1.backgroundColor = Color.black;

			cam1.depth = 0;
		}

		if(rg.position.y < -20.0f) respawnPlayer();

		stopAnimations ();
		
		direction = Input.GetAxis("HorizontalP1");
		rg.velocity = new Vector2(direction*MoveSpeed,rg.velocity.y);
	}

	void Raycast()
	{
		Debug.DrawLine(lineStart.position,lineEndLeft.position,Color.red);
		Debug.DrawLine(lineStart.position,lineEndRight.position,Color.red);
		//Debug.DrawLine(lineStartLeft.position,lineEndLeft.position,Color.red);
		
		isGrounded = Physics2D.Linecast(lineStart.position,lineEndLeft.position,1 << LayerMask.NameToLayer("Plataformas")) 
			|| Physics2D.Linecast(lineStart.position,lineEndRight.position,1 << LayerMask.NameToLayer("Plataformas"));
			
			
	}

	public void jump() {

		if (isGrounded && rg.velocity.y <= 0.1f) {
			//rg.velocity = new Vector2 (rg.velocity.x, jumpHeight);
			rg.AddForce(Vector2.up * jumpHeight);
			anim.SetBool ("isJumping", true);
		}
	}

	void meleeAttack() {

		LayerMask layerMark = 1 << LayerMask.NameToLayer ("NPC") | 1 << LayerMask.NameToLayer ("Negro");
		RaycastHit2D hit = Physics2D.Linecast (meleeStart.position, meleeEnd.position, layerMark);
		RaycastHit2D hit2 = Physics2D.Linecast (meleeStart2.position, meleeEnd2.position, layerMark);
		Debug.DrawLine(meleeStart.position,meleeEnd.position,Color.green);
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();

		bool appliedDamage = false;

		if (hit && hit.collider && !appliedDamage) {
		
			if (hit.collider.gameObject.CompareTag ("NPC")) {

				hit.collider.gameObject.GetComponent<Damage> ().ApplyDamage (-1f);
				appliedDamage = true;
			}
		}

		if (hit2 && hit2.collider && !appliedDamage) {
			
			if (hit2.collider.gameObject.CompareTag ("NPC")) {
				
				hit2.collider.gameObject.GetComponent<Damage> ().ApplyDamage (-1f);
				appliedDamage = true;
			}
		}

		appliedDamage = false;
	}

	void grabTribute() {
		
		RaycastHit2D hit = Physics2D.Linecast (meleeStart.position, meleeEnd.position, 1 << LayerMask.NameToLayer ("ObjetosFijos"));
		Debug.DrawLine(meleeStart.position,meleeEnd.position,Color.green);
		if (hit != null && hit.collider != null) {
			
			if(hit.collider.gameObject.CompareTag("Tribute")) {
				
				//hit.collider.gameObject.transform.position = new Vector2(transform.position.x+meleeEnd.position.x,hit.collider.gameObject.transform.position.y);
				tribute = hit.collider;
				tribute.transform.parent = transform;
				tribute.GetComponent<Collider2D>().attachedRigidbody.gravityScale = 0;
				tribute.GetComponent<Collider2D>().attachedRigidbody.isKinematic = true;
				//hit.collider.isTrigger = true;
				tribute.transform.localPosition = meleeEnd.transform.localPosition;
				hasTribute = true;
				//Debug.Log("Te agarre " + hit.collider.gameObject.name);

			}
		}
	}

	void dropTribute(){

		if(tribute.CompareTag("Tribute")){
			tribute.transform.parent = null;
			tribute.GetComponent<Collider2D>().attachedRigidbody.gravityScale = 5;
			tribute.GetComponent<Collider2D>().attachedRigidbody.isKinematic = false;
			//child.isTrigger = false;
			tribute.GetComponent<Collider2D>().attachedRigidbody.AddForce(new Vector2(Mathf.Sign(transform.localScale.x)*500,500));
			hasTribute=false;
		}
	}

	void stopAnimations(){

		if (anim.GetBool ("isJumping"))
			anim.SetBool ("isJumping", false);

		if (anim.GetBool ("isAttacking"))
			anim.SetBool ("isAttacking", false);

	}

	void respawnPlayer() {
		cam1.depth = 1;
		transform.position = spawnPoint;

	}
	
}
