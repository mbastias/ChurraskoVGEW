using UnityEngine;
using System.Collections;

public class Rojo : NpcBase {

	public float limitXizq;
	public float limitXder;
	public float jumpHeight;

	new void Awake()
	{
		base.Awake();
		WalkHorWoF = false;
	}
	new void Update()
	{
		
	}
	new void FixedUpdate()
	{
		Raycast();
		
		rg.velocity = new Vector2(directionX * MoveSpeedX * Time.deltaTime, rg.velocity.y);
		
		if(transform.position.x >= limitXder)
		{
			if(rg.velocity.x > 0)
			{
				directionX = -1;
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y, transform.localScale.z);
			}	
			
		}
		if(transform.position.x <= limitXizq)
		{
			if(rg.velocity.x < 0)
			{
				directionX = 1;
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y, transform.localScale.z);
			}
		}
		
		if(isGrounded && rg.velocity.y <= 0.1f)
		{
			rg.AddForce(Vector2.up * jumpHeight);
		}
		
		
	}
}
