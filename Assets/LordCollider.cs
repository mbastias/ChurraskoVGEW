using UnityEngine;
using System.Collections;

public class LordCollider : MonoBehaviour {

	public AudioSource Bramido;
	private float MaxHappiness = 20;
	public float currentHappiness = 0;
	
	public void HappVariation(float variation,int god)
	{
		currentHappiness += variation;
		if(god == 1)
		{
			HealthBar1.hb.ShowHealth(MaxHappiness,currentHappiness);
		}
		if(god == 2)
		{
			HealthBar2.hb.ShowHealth(MaxHappiness,currentHappiness);
			Debug.Log("Este es el dios 2");
		}
	}
	void Start(){
		Bramido = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.gameObject.CompareTag("Tribute")) {
			
			Debug.Log(collider.gameObject.name + " " + gameObject.name);
			
			if(gameObject.name == "Dios1")
			{
				if(collider.gameObject.name == "Corazon")
				{
					HappVariation(5f,1);
				}
				else
				{
					HappVariation(1f,1);
				}
			}
			if(gameObject.name == "Dios2")
			{
				if(collider.gameObject.name == "Corazon")
				{
					HappVariation(5f,2);
				}
				else
				{
					HappVariation(1f,2);
				}
			}
			Destroy(collider.gameObject);
			Bramido.Play();
		}
	}
}
