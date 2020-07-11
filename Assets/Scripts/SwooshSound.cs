using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class SwooshSound : MonoBehaviour
{
    public AudioClip swoosh;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= swoosh;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}