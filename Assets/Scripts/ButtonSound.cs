using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class ButtonSound : MonoBehaviour
{
    public AudioClip button;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= button;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}