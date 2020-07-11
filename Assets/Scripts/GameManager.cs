using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //Need this here?

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


//Timer

   type variableName = playedTime : float;
   type variableName = timeDisplay : GUIText;
 
 public void Start(){
     playedTime = 0.0;
 }    
 
 public void Update(){
 
     playedTime += Time.deltaTime;
     timeDisplay.text = Mathf.RoundToInt(playedTime).ToString();
 
 }



//Score system:

     public int score = 0;

    public void scoreUp () {
        score++;
        Debug.Log("Score: " + score);
    }

    public void scoreReset () {
        score = 0;
    }

}

  



