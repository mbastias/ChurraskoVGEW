using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

	private Rigidbody2D rg;
	public Transform lineStart,lineEndLeft,lineEndRight;
	public Transform meleeStart, meleeEnd;
	//public Transform lineEndLeft;
	//public Transform lineStartLeft;
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

	// Use this for initialization
	void Awake () {
	
		rg = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		isGrounded = false;
		hasTribute = false;
	
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

		if (isGrounded) {
			//rg.velocity = new Vector2 (rg.velocity.x, jumpHeight);
			rg.AddForce(Vector2.up * jumpHeight);
			anim.SetBool ("isJumping", true);
		}
	}

	void meleeAttack() {

		RaycastHit2D hit = Physics2D.Linecast (meleeStart.position, meleeEnd.position, 1 << LayerMask.NameToLayer ("NPC") | 
		                                       1 << LayerMask.NameToLayer ("Negro"));
		Debug.DrawLine(meleeStart.position,meleeEnd.position,Color.green);
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
		if (hit != null && hit.collider != null) {
		
			if(hit.collider.gameObject.CompareTag("NPC")) {

				hit.collider.gameObject.GetComponent<Damage>().ApplyDamage(-1f);
				Debug.Log("Te pegue " + hit.collider.gameObject.name);
			}
		}
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
	
}
