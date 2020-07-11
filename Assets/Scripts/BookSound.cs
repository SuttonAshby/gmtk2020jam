using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class BookSound : MonoBehaviour
{
    public AudioClip rustle;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= rustle;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}