using UnityEngine;
using System.Collections;

public class CallRescueOperation : MonoBehaviour
{
	AudioClip heliCall;
	Helicopter heli;

	void Start ()
	{
		heli = GameObject.FindObjectOfType<Helicopter> ();
		heliCall = Resources.Load ("Audio/heli_call") as AudioClip;
	
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
}
