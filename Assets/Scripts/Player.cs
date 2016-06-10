using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	AudioClip heliCall, clearArea, whatHappened;
	Helicopter heli;

	AudioSource[] m_AudioSources;
	AudioSource m_AudioSource;

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
	void Update ()
	{

		if (Input.GetButton ("CallHeli") && !heli.called) {
			CallRescue ();
		}

	}

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
	}
}
