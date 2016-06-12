using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	AudioClip heli_call_sound, clear_area_sound, what_happened_sound, flare_sound, fw_launch_sound, fw_blast_sound;
	Helicopter heli;

	AudioSource[] m_AudioSources;
	AudioSource m_AudioSource;
	GameObject flare, fireworks;

	void Start ()
	{
		m_AudioSources = GetComponents <AudioSource> ();
		foreach (AudioSource audioSource in m_AudioSources) {
			if (audioSource.priority == 1) {
				m_AudioSource = audioSource;
			}
		}
	
		heli = GameObject.FindObjectOfType<Helicopter> ();
		heli_call_sound = Resources.Load ("Audio/heli_call") as AudioClip;
		clear_area_sound = Resources.Load ("Audio/clear_area") as AudioClip;	
		what_happened_sound = Resources.Load ("Audio/what_happened") as AudioClip;	
		flare_sound = Resources.Load ("Audio/flare") as AudioClip;	
		fw_launch_sound = Resources.Load ("Audio/fireworks_launch") as AudioClip;	
		fw_blast_sound = Resources.Load ("Audio/fireworks_blast") as AudioClip;	
		m_AudioSource.clip = what_happened_sound;
		m_AudioSource.Play ();
	}
	// Update is called once per frame


	void CallRescue ()
	{
//		source.spatialBlend = 0.0f;
		m_AudioSource.clip = heli_call_sound;
		m_AudioSource.Play ();
		heli.ReceiveRescueCall ();
	}

	void OnFindClearArea ()
	{
		m_AudioSource.clip = clear_area_sound;
		m_AudioSource.Play ();
		Invoke ("CallRescue", clear_area_sound.length + 2);
		LaunchVisibleHelp ();

	}

	void LaunchVisibleHelp ()
	{
		LaunchFlare ();
//		Invoke ("LaunchFireworks", clear_area_sound.length + 5f);
		LaunchFireWorks ();
	}

	void LaunchFlare ()
	{
		flare = Instantiate (Resources.Load ("Prefabs/Flare"), transform.position + Vector3.forward, Quaternion.identity)as GameObject;
		flare.name = "flare";
		AudioSource.PlayClipAtPoint (flare_sound, transform.position);

	}

	void LaunchFireWorks ()
	{
		fireworks = Instantiate (Resources.Load ("Prefabs/Fireworks"), transform.position + Vector3.forward, Quaternion.identity) as GameObject;
		fireworks.name = "fireworks";
		AudioSource.PlayClipAtPoint (fw_launch_sound, transform.position);
		AudioSource.PlayClipAtPoint (fw_blast_sound, transform.position + Vector3.up * 10);

	}
}
