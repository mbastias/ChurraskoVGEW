using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rg;
	public Transform lineEndRight;
	public Transform lineStartRight;
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
		
	}
	
	void FixedUpdate () 
	{
		anim.SetFloat("SpeedX",rg.velocity.x);
		Raycast();	
		if (rg.velocity.x != 0) {
			anim.SetBool ("isWalking", true);
			
			
			
			if (rg.velocity.x > 0) 
				transform.localScale = new Vector3 (Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
			
			else if (rg.velocity.x < 0)
				transform.localScale = new Vector3 (-Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
		} else {
			anim.SetBool ("isWalking", false);
		}
		
		if(Input.GetButtonDown("Jump"))
		{
			jump();
		}
		
		direction = Input.GetAxis("Horizontal");
		rg.velocity = new Vector2(direction*MoveSpeed,rg.velocity.y);
	}

	void Raycast()
	{
		Debug.Log("hola");	
		Debug.DrawLine(lineStartRight.position,lineEndRight.position,Color.red);
		//Debug.DrawLine(lineStartLeft.position,lineEndLeft.position,Color.red);
		
		isGrounded = Physics2D.Linecast(lineStartRight.position,lineEndRight.position,1 << LayerMask.NameToLayer("Ground")) ;
					//|| Physics2D.Linecast(lineStartLeft.position,lineEndLeft.position,1 << LayerMask.NameToLayer("Ground")) ;
			
			
	}

	public void jump() {

		if (isGrounded) {
			//rg.velocity = new Vector2 (rg.velocity.x, jumpHeight);
			rg.AddForce(Vector2.up * jumpHeight);
		}
	}


	
}
