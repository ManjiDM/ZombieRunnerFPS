using UnityEngine;
using System.Collections;

public class CallRescueOperation : MonoBehaviour
{
	AudioClip heliCall;
	GameObject heli;

	void Start ()
	{
		heli = GameObject.Find ("Helicopter");
		heliCall = Resources.Load ("Audio/heli_call") as AudioClip;
	}
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButton ("CallHeli")) {
			CallRescue ();
		}
	
	
	}

	void CallRescue ()
	{
		
		AudioSource.PlayClipAtPoint (heliCall, transform.position);

	
	}
}
