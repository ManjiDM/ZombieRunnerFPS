using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour
{

	private Camera eyes;
	private float defaultFOV;
	private bool zoomed = false;
	// Use this for initialization
	void Start ()
	{
		eyes = GetComponentInChildren<Camera> ();
		defaultFOV = eyes.fieldOfView;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetButtonDown ("Zoom") && !zoomed) {
			
			eyes.fieldOfView /= 10f;
		} else if (Input.GetButtonUp ("Zoom")) {
			eyes.fieldOfView = defaultFOV;
			zoomed = false;
		}

	
	}
}
