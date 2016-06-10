using UnityEngine;
using System.Collections;


public class Underwater : MonoBehaviour
{
	 
	float waterLevel;
	bool isUnderwater;
	Color fogColor;
	Color underwaterColor;
	float fogDensity;
	float underwaterDensity;
	Rigidbody rBody;
	GameObject underwaterTable;
	MeshRenderer meshR;

	void Start ()
	{
		rBody = GetComponentInParent <Rigidbody> ();
		underwaterTable = GameObject.Find ("UnderwaterTable");
		meshR = underwaterTable.GetComponent<MeshRenderer> ();
		meshR.enabled = false;
		waterLevel = underwaterTable.transform.position.y - 1;
		RenderSettings.fogColor = new Color (.5f, .5f, .5f, .5f);	
		RenderSettings.fogDensity = 0.005f;
		fogColor = RenderSettings.fogColor;
		fogDensity = RenderSettings.fogDensity;
		underwaterColor = new Color (.33f, .76f, .88f, .7f);
		underwaterDensity = .009f;
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
		if (Input.GetKeyDown (KeyCode.M))
			EnableMesh ();
	}

	void EnterWater ()
	{
		EnableMesh ();
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = underwaterDensity;
		rBody.mass = .1f;
	}

	void ExitWater ()
	{
		EnableMesh ();
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
		rBody.mass = 1f;
	}

	void EnableMesh ()
	{
		meshR.enabled = !meshR.enabled;
	}

}
