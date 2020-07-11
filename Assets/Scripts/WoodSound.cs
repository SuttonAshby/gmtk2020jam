using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class WoodSound : MonoBehaviour
{
    public AudioClip wood;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= wood;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}