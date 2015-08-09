using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rg;
	public Transform lineEndRight,lineStartRight;
	public Transform meleeStart, meleeEnd;
	//public Transform lineEndLeft;
	//public Transform lineStartLeft;
	public float MoveSpeed;
	private float direction;
	private float movement;
	public float jumpHeight;
	public bool isGrounded;
	private Animator anim;
	
	


	// Use this for initialization
	void Awake () {
	
		rg = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		isGrounded = false;
	
	}
	
	// Update is called once per frame
	void Update()
	{
		Raycast();

		if(Input.GetButtonDown("Jump"))
		{
			jump();
		}

		if (Input.GetButtonDown ("Fire1")) {
			meleeAttack();
			anim.SetBool("isAttacking",true);
		}
	}
	
	void FixedUpdate () 
	{
		stopAnimations ();

		if (!isGrounded)
			anim.SetBool ("isJumping", true);

		if (rg.velocity.x > 0) 
			transform.localScale = new Vector3 (Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
		
		else if (rg.velocity.x < 0)
			transform.localScale = new Vector3 (-Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);

		if (rg.velocity.x != 0) {
			anim.SetBool ("isWalking", true);

		} else {
			anim.SetBool ("isWalking", false);
		}
		
		direction = Input.GetAxis("Horizontal");
		rg.velocity = new Vector2(direction*MoveSpeed*Time.fixedDeltaTime,rg.velocity.y);
	}

	void Raycast()
{
		Debug.DrawLine(lineStartRight.position,lineEndRight.position,Color.red);
		//Debug.DrawLine(lineStartLeft.position,lineEndLeft.position,Color.red);
		
		isGrounded = Physics2D.Linecast(lineStartRight.position,lineEndRight.position,1 << LayerMask.NameToLayer("Plataformas")) ;
					//|| Physics2D.Linecast(lineStartLeft.position,lineEndLeft.position,1 << LayerMask.NameToLayer("Ground")) ;
			
			
	}

	public void jump() {

		if (isGrounded) {
			//rg.velocity = new Vector2 (rg.velocity.x, jumpHeight);
			rg.AddForce(Vector2.up * jumpHeight);
		}
	}

	void meleeAttack() {

		RaycastHit2D hit = Physics2D.Linecast (meleeStart.position, meleeEnd.position, 1 << LayerMask.NameToLayer ("NPC"));
		Debug.DrawLine(meleeStart.position,meleeEnd.position,Color.green);
		if (hit != null && hit.collider != null) {
		
			if(hit.collider.gameObject.CompareTag("NPC")) {

				hit.collider.gameObject.GetComponent<Damage>().ApplyDamage(-1f);
				Debug.Log("Te pegue " + hit.collider.gameObject.name);
			}
		}
	}

	void stopAnimations(){

		if (anim.GetBool ("isJumping"))
			anim.SetBool ("isJumping", false);

		if (anim.GetBool ("isAttacking"))
			anim.SetBool ("isAttacking", false);

	}
	
}
