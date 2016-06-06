using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour
{

	public bool called = false;
	AudioClip clip;
	GameObject helicopter;

	void Awake ()
	{

		helicopter = GameObject.Find ("Helicopter");
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
		called = true;
		   
		Invoke ("RespondToCall", 10);
	}

	private void RespondToCall ()
	{
//		source.spatialBlend = 0.0f;
		AudioSource.PlayClipAtPoint (clip, GameObject.Find ("Player").transform.position);

	}
}
