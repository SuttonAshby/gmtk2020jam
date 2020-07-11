using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class LaptopSound : MonoBehaviour
{
    public AudioClip laptop;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= laptop;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}