using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class ErrorSound : MonoBehaviour
{
    public AudioClip error;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= error;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}