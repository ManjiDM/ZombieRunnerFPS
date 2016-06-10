using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour
{

	public bool called = false;
	AudioClip clip;
	AudioSource source;
	GameObject helicopter;
	Rigidbody rBody;

	void Awake ()
	{
		source = GetComponent <AudioSource> ();
		helicopter = GameObject.Find ("Helicopter");
		rBody = helicopter.GetComponent <Rigidbody> ();
		helicopter.SetActive (false);
	}
	// Use this for initialization
	void Start ()
	{
		clip = Resources.Load ("Audio/call_reply") as AudioClip;
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.RightControl))
			helicopter.SetActive (!helicopter.activeSelf);
	}

	public void ReceiveRescueCall ()
	{
		if (called)
			return;
		called = true;
		   
		Invoke ("RespondToCall", 10);
		Invoke ("SendHeli", 13);
	}

	void RespondToCall ()
	{
//		source.spatialBlend = 0.0f;
		source.clip = clip;
		source.Play ();

	}

	void SendHeli ()
	{
		helicopter.SetActive (true);
		rBody.velocity = new Vector3 (0, 0, 50f);
	}
}
