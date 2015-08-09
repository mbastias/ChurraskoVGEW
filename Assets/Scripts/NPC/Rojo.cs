using UnityEngine;
using System.Collections;

public class Rojo : NpcBase {

	public float limitX;
	public float jumpHeight;

	new void Awake()
	{
		base.Awake();
		WalkHorWoF = false;
	}
	
	new void FixedUpdate()
	{
		Raycast();
		
		rg.velocity = new Vector2(directionX * MoveSpeedX * Time.deltaTime, rg.velocity.y);
		
		if(Mathf.Abs(transform.position.x) >= limitX)
		{
			directionX = -directionX;
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y, transform.localScale.z);
		}
		
		if(isGrounded)
		{
			rg.AddForce(Vector2.up * jumpHeight);
		}
		
		
	}
}
