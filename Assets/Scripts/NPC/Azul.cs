using UnityEngine;
using System.Collections;

public class Azul : NpcBase {


	public Transform lookRightEnd;
	public Transform lookLeftEnd;
	public Transform lookStart;

	new void Awake()
	{
		base.Awake();
	}
	
	new void Update(){}
	
	new void FixedUpdate()
	{
		Raycast();
	
		if(WalkHorWoF == true)
		{
			WalkHorizontalNoFallling();
		}
	}
	
	new void Raycast()
	{
		base.Raycast();
		
		Debug.DrawLine(lookStart.position,lookLeftEnd.position,Color.green);
		Debug.DrawLine(lookStart.position,lookRightEnd.position,Color.green);
		
		if(Physics2D.Linecast(lookStart.position,lookRightEnd.position, 1 << LayerMask.NameToLayer("Player1") )
		   && Physics2D.Linecast(lookStart.position,lookLeftEnd.position, 1 << LayerMask.NameToLayer("Player2"))
		   || Physics2D.Linecast(lookStart.position,lookRightEnd.position, 1 << LayerMask.NameToLayer("Player2") )
		   && Physics2D.Linecast(lookStart.position,lookLeftEnd.position, 1 << LayerMask.NameToLayer("Player1")))
		{
			rg.velocity = new Vector2(0,rg.velocity.y);
			WalkHorWoF = false;
		}
		
		else
		{
		
			if(Physics2D.Linecast(lookStart.position,lookLeftEnd.position, 1 << LayerMask.NameToLayer("Player1") )
			   || Physics2D.Linecast(lookStart.position,lookLeftEnd.position, 1 << LayerMask.NameToLayer("Player2")))
			{
				WalkHorWoF = true;
				directionX = directionX;
			}
			if(Physics2D.Linecast(lookStart.position,lookRightEnd.position, 1 << LayerMask.NameToLayer("Player1")) 
			                      || Physics2D.Linecast(lookStart.position,lookRightEnd.position, 1 << LayerMask.NameToLayer("Player2")))
			{
				WalkHorWoF = true;
				directionX = -directionX;
				setDirectionX();
				
			}
		}
		

	}
	
	
}
