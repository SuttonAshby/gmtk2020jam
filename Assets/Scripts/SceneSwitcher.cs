using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
	public void GotoMenu (string scenename)
	{
		Application.LoadLevel (scenename);
	}

}