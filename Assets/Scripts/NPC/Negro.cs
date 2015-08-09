using UnityEngine;
using System.Collections;

public class Negro : NpcBase {

	public Transform LookStart;
	public Transform LookEnd;
	public float HitPowah;
	public float HitPowahY;
	public float RunPowah;
	
	private RaycastHit2D rh2;

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
		
		if(rh2 = Physics2D.Linecast(LookStart.position,LookEnd.position, 1 << LayerMask.NameToLayer("Player1") 
		| 1 << LayerMask.NameToLayer("Player2")))
		{
			rg.AddForce(new Vector2(Mathf.Sign(rh2.transform.position.x - transform.position.x)*RunPowah,0));
		}
		
		
	}
	
	void OnCollisionEnter2D(Collision2D hit)
	{
		Debug.Log("Entre");
		 if(hit.transform.CompareTag("Player"))
		 {
		 	Debug.Log("hello");
		 	hit.rigidbody.AddForce(new Vector2(Mathf.Sign()*HitPowah,HitPowahY));
		 }
	}
	
	
}
