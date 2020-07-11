using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class GenoratorSound : MonoBehaviour
{
    public AudioClip genorator;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= genorator;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}