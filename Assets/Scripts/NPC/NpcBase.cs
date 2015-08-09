using UnityEngine;
using System.Collections;

public class NpcBase : MonoBehaviour {

	//Flags
	//Walk horizontal without falling
	public bool WalkHorWoF;

	//Linecast extremes.
	public Transform lineStart;
	public Transform lineEnd;

	//This npc rigidbody.
	protected Rigidbody2D rg;
	
	//HorizontalMovement
	public float MoveSpeedX;
	protected bool isGrounded;
	private float directionX = 1;

	//Main animator
	protected Animator anim;
	 
	// Use this for initialization
	void Awake () 
	{
		rg = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		WalkHorWoF = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	protected void FixedUpdate()
	{
		anim.SetFloat("SpeedX",rg.velocity.x);
	
		Raycast();
		
		
		
		
		if(rg.velocity.x != 0 && rg.velocity.y <= Mathf.Abs(0.1f))
		{
			anim.SetBool("isWalking",true);
			
		}
		else anim.SetBool("isWalking",false);
		
		if(WalkHorWoF == true)
		{
			WalkHorizontalNoFallling();
		}
		
	}
	
	protected void Raycast()
	{
		Debug.DrawLine(lineStart.position,lineEnd.position,Color.red);
		
		isGrounded = Physics2D.Linecast(lineStart.position,lineEnd.position,1 << LayerMask.NameToLayer("Plataformas"));		
	}
	
	private void WalkHorizontalNoFallling()
	{
		if(!isGrounded)
		{
			if(Mathf.Abs(rg.velocity.y) < 0.1)
			{
				directionX = -directionX;
			}
			setDirectionX();
		}
		
		rg.velocity = new Vector2(directionX * MoveSpeedX * Time.deltaTime, rg.velocity.y);
		
		
	}
	
	private void setDirectionX()
	{
	
		if(directionX > 0)
		{
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
		}
		else if(directionX < 0) transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);	
	}
}
