using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	protected float directionX = 1;

	//Main animator
	protected Animator anim;
	 
	// Use this for initialization
	protected void Awake () 
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
		Raycast();
		
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
	
	protected void WalkHorizontalNoFallling()
	{
		if(!isGrounded)
		{
			if(Mathf.Abs(rg.velocity.y) < 0.1)
			{
				directionX = -directionX;
			}
			setDirectionX();
		}
		
		rg.velocity = new Vector2(directionX * MoveSpeedX * Time.fixedDeltaTime, rg.velocity.y);
		
		
	}
	
	protected void setDirectionX()
	{
	
		if(directionX > 0)
		{
			transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
		}
		else if(directionX < 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);	
	}
	
	
	
	
}
