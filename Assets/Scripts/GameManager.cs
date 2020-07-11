using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance {get; private set; }

	private void Awake () {
        //Initiate singleton
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

   variableName = playedTime : float;
   variableName = timeDisplay : GUIText;
 
 void Start(){
     playedTime = 0.0;
 }    
 
 void Update(){
 
     playedTime += Time.deltaTime;
     timeDisplay.text = Mathf.RoundToInt(playedTime).ToString();
 
 }
}

  



