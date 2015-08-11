using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar2 : MonoBehaviour {

	public static HealthBar2 hb;
	private float width;
	private float posDelta;
	private RectTransform rect;
	public Color normal;
	public Color damaged;
	private float maxValue = 1.0f;
	private float minValue = 0.0f; 
	private Image image;
	
	// Use this for initialization
	void Awake () {
		hb = this;
		rect = GetComponent<RectTransform>();
		width = rect.sizeDelta.x+1;
		Debug.Log("width "+ width.ToString());
		if(image == null) image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	public void ShowHealth(float maxhealth,float health)
	{	
		posDelta = width - ((health*width)/maxhealth);
		rect.localPosition = new Vector3(0-posDelta,rect.localPosition.y,0);
		image.color = Color.Lerp(damaged,normal,Mathf.Lerp(minValue,maxValue,health/maxhealth));
	}
}
