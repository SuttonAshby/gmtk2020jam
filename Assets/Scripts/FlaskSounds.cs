using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskSounds : MonoBehaviour
{
    public AudioClip Clink;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= Clink;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}