using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class LampSound : MonoBehaviour
{
    public AudioClip lamp;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= lamp;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}