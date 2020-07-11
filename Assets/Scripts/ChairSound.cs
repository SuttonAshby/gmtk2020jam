using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class ChairSound : MonoBehaviour
{
    public AudioClip chair;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= chair;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}