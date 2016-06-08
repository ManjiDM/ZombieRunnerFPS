using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour
{
	AudioClip clearArea;
	float clearTime	= 0f;
	bool areaFound = false;
	// Use this for initialization
	void Start ()
	{
		clearArea = Resources.Load ("Audio/clear_area") as AudioClip;
	}
	
	// Update is called once per frame
	void Update ()
	{
		clearTime += Time.deltaTime;
		if (clearTime > 2f && !areaFound) {
			areaFound = !areaFound;
			AudioSource.PlayClipAtPoint (clearArea, transform.parent.position);
		}
			
	}

	void OnTriggerStay ()
	{
		clearTime = 0f;
	}
}
