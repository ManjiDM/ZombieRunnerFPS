using UnityEngine;
using System.Collections;


public class Underwater : MonoBehaviour
{
	 
	float waterLevel;
	bool isUnderwater;
	public Color fogColor;
	public Color underwaterColor;
	public float fogDensity;
	public float underwaterDensity;

	void Start ()
	{
		waterLevel = GameObject.Find ("WaterTable").transform.position.y;
		fogColor = RenderSettings.fogColor;
		fogDensity = RenderSettings.fogDensity;
		underwaterColor = new Color (.33f, .76f, .88f, .7f);
		underwaterDensity = .02f;
	}

	void Update ()
	{
		if ((transform.position.y < waterLevel) != isUnderwater) {
			isUnderwater = transform.position.y < waterLevel;
			if (isUnderwater) {
				EnterWater ();
			} else {
				ExitWater ();
			}
		}
	}

	void EnterWater ()
	{
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = underwaterDensity;
	}

	void ExitWater ()
	{
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
	}

}
