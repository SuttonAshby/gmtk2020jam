using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class Metal_thudSound : MonoBehaviour
{
    public AudioClip metal_thud;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= metal_thud;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}