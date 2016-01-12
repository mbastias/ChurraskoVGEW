using UnityEngine;
using System.Collections;

public class Negro : NpcBase {

		public Transform LookStart;
		public Transform LookEnd;
		public float HitPowah;
		public float HitPowahY;
		public float RunPowah;
		public float stunTime;
		
		private bool Attack = false;
		
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
							gameObject.layer = LayerMask.NameToLayer("Negro");
							Attack = true;
					}
				
					
			}
		
			void OnCollisionStay2D(Collision2D hit)
		{
				 if(hit.transform.CompareTag("Player") && Attack == true)
				 {		
						StartCoroutine(hit.gameObject.GetComponent<Player1Movement>().Stun(stunTime));
					 	hit.rigidbody.AddForce(new Vector2(Mathf.Sign(-transform.localScale.x)*HitPowah,HitPowahY));
					 	rg.velocity= Vector2.zero;
					 	gameObject.layer = LayerMask.NameToLayer("NPC");
					 	Attack = false;						 	
				 }
			}
		
			
	}