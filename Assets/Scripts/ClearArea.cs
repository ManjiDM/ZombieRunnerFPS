using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour
{
	AudioClip clearArea;
	public float clearTime	= 0f;
	bool areaFound = false;

	// Update is called once per frame
	void Update ()
	{
		clearTime += Time.deltaTime;
		print (clearTime);
		if (clearTime > 10f && !areaFound) {
			areaFound = !areaFound;
			SendMessageUpwards ("OnFindClearArea");
		}
			
	}

	void OnTriggerStay (Collider col)
	{
		if (col.name != "Player") {
			clearTime = 0f;
		}
	}
}
