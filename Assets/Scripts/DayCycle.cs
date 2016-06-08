using UnityEngine;
using System.Collections;
using UnityEditor;

public class DayCycle : MonoBehaviour
{

	[Tooltip ("each second of real life represent minutes in game if value 60")]
	public float minutesPerSecond = 60;
	private Quaternion startRotation;

	// Update is called once per frame
	void Update ()
	{
		float angle = Time.deltaTime / 360 * minutesPerSecond;
		transform.RotateAround (transform.position, Vector3.forward, angle);
	}
}
