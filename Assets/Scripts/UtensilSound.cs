using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class UtensilSound : MonoBehaviour
{
    public AudioClip utensil;
	void Start ()
	{
		GetComponent<AudioSource> () .clip= utensil;
	}

	void OnCollisionEnter ()
	{
		GetComponent<AudioSource> () .Play ();
	}
}