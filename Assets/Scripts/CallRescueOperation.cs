using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class CallRescueOperation : MonoBehaviour
{
	AudioClip heliCall, clearArea;
	Helicopter heli;

	void Start ()
	{
		heli = GameObject.FindObjectOfType<Helicopter> ();
		heliCall = Resources.Load ("Audio/heli_call") as AudioClip;
		clearArea = Resources.Load ("Audio/clear_area") as AudioClip;	
	}
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButton ("CallHeli") && !heli.called) {
			CallRescue ();
		}

	}

	void CallRescue ()
	{
//		source.spatialBlend = 0.0f;
		AudioSource.PlayClipAtPoint (heliCall, transform.position);
		heli.ReceiveRescueCall ();
	}

	void OnFindClearArea ()
	{
		AudioSource.PlayClipAtPoint (clearArea, transform.position);
	}
}
