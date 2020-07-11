using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class AppleSound : MonoBehaviour
{
    public AudioClip light_thud;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= light_thud;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}