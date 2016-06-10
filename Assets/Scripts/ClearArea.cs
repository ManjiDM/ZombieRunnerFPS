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
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		clearTime += Time.deltaTime;
		if (clearTime > 2f && !areaFound) {
			areaFound = !areaFound;
			SendMessageUpwards ("OnFindClearArea");
		}
			
	}

	void OnTriggerStay ()
	{
		clearTime = 0f;
	}
}
