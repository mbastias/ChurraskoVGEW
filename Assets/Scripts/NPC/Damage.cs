using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	//Health
	public float health;
	public float hearthProb;
	
	//Drops
	//public Dictionary<String,GameObject> Drops; 
	public GameObject[] drops;
	public Vector3 lastPosition;	

	public void HealthVaration(float variation)
	{
		health += variation; 
		if(health == 0)
		{
			DieAndReplace();
		}
	}
	
	public void ApplyDamage(float damage)
	{
		HealthVaration(damage);
	}
	
	public void DieAndReplace()
	{
		lastPosition = transform.position;
		gameObject.SetActive(false);
		if(Dices.prob(1- hearthProb))
		{
			drops[0].transform.position = lastPosition;
			drops[0].SetActive(true);
		}
		else
		{
			int index = Dices.dice(0,4);
			Debug.Log(index);
			drops[index].transform.position = lastPosition;
			drops[index].SetActive(true);
		}

	}
}
