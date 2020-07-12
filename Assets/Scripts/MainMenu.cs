using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
	public bool isInstructions;
	public bool isCredits;
	void OnMouseUp () {
	if(isStart){
	Application.LoadLevel (3);
	}
	if (isInstructions){
	Application.LoadLevel (1);
	}
	if (isCredits){
	Application.LoadLevel (2);
	}
}
}