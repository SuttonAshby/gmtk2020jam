using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public bool isPlaying = false;

//Timer

   public float playedTime;
   public Text timeDisplay;
   public Text foundDisplay;

 public void Start(){
     isPlaying = true;
     playedTime = 0f;
 }    
 
 public void Update(){
 
    if(isPlaying){
        playedTime += Time.deltaTime;
        timeDisplay.text = "Time: " + Mathf.RoundToInt(playedTime);
        foundDisplay.text = "Found: " + GoalController.Instance.timesFound;
    }
     
     
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

  



