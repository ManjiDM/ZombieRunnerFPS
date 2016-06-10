using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	AudioClip heliCall, clearArea, whatHappened;
	Helicopter heli;

	AudioSource[] m_AudioSources;
	AudioSource m_AudioSource;
	GameObject flare;

	void Start ()
	{
		m_AudioSources = GetComponents <AudioSource> ();
		foreach (AudioSource audioSource in m_AudioSources) {
			if (audioSource.priority == 1) {
				m_AudioSource = audioSource;
			}
		}
	
		heli = GameObject.FindObjectOfType<Helicopter> ();
		heliCall = Resources.Load ("Audio/heli_call") as AudioClip;
		clearArea = Resources.Load ("Audio/clear_area") as AudioClip;	
		whatHappened = Resources.Load ("Audio/what_happened") as AudioClip;	
		m_AudioSource.clip = whatHappened;
		m_AudioSource.Play ();
	}
	// Update is called once per frame


	void CallRescue ()
	{
//		source.spatialBlend = 0.0f;
		m_AudioSource.clip = heliCall;
		m_AudioSource.Play ();
		heli.ReceiveRescueCall ();
	}

	void OnFindClearArea ()
	{
		m_AudioSource.clip = clearArea;
		m_AudioSource.Play ();
		Invoke ("LaunchFlare", clearArea.length + 2f);
		Invoke ("CallRescue", clearArea.length +	5f);
	}

	void LaunchFlare ()
	{
		flare = Instantiate (Resources.Load ("Prefabs/Flare"), transform.position + Vector3.forward, Quaternion.identity)as GameObject;
		flare.name = "flare";
	}
}
