using UnityEngine;
using System.Collections;


public class Lantern : MonoBehaviour
{

	private Light lantern;
	// Use this for initialization
	void Start ()
	{
		lantern = GetComponent <Light> ();
		lantern.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.L)) {
			ToggleLight ();
		}
	}

	void ToggleLight ()
	{
		lantern.enabled = !lantern.enabled;
	}
}
