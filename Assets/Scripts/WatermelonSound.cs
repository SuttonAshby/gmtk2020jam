using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class WatermelonSound : MonoBehaviour
{
    public AudioClip big_thud;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= big_thud;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}