using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class BowlSound : MonoBehaviour
{
    public AudioClip bowl;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= bowl;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}