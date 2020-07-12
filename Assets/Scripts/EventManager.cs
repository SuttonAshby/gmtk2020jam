using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance {get; private set; }
    //trigger strings
    public string gravity = "changeGravity";
    public string camera = "changeCamera";
    public string drag = "changeDrag";

    public string playerInput = "flipPlayerInput";

    public float minEventTimer = 10f;
    public float maxEventTimer = 25f;
    public float nextEventTimeLeft = 10f;
    bool timerActive = true;

    List<string> activeTriggers = new List<string>();

    List<string> allTriggers = new List<string>();

    private void Start () {
        allTriggers.Add(gravity);
        allTriggers.Add(camera);
        allTriggers.Add(drag); 
        allTriggers.Add(playerInput);
    }

	private void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(nextEventTimeLeft > 0 && timerActive == true){
            nextEventTimeLeft -= Time.deltaTime;
        } else {
            triggerRandomEffect();
        }
    }

    void triggerRandomEffect(){
        timerActive = false;
        int addOrRemove = Random.Range(0, 100);
        if(activeTriggers.Count < 3){
            //minimum adding
            Debug.Log("Mimimum Adding");
            addRandomTrigger();
        } else if(addOrRemove <= 30){
            //add
            Debug.Log("Adding");
            addRandomTrigger();
        } else if(30 < addOrRemove && addOrRemove <= 60){
            //remove
            Debug.Log("Removing");
            removeRandomTrigger();
        } else if(60 < addOrRemove && addOrRemove <= 90){
            //add and remove
            Debug.Log("Adding and Removing");
            addRandomTrigger();
            removeRandomTrigger();
        } else {
            //reset
            Debug.Log("Resetting");
            resetTriggers();

        }
        setNewTimer();
    }

    void setNewTimer(){
        nextEventTimeLeft = Random.Range(minEventTimer, maxEventTimer+1);
        timerActive = true;
    }

    void addRandomTrigger(){
        int trigger = Random.Range(0, allTriggers.Count);
        if(allTriggers[trigger] == gravity){
            changeGravity(false);
            if(!activeTriggers.Contains(gravity)){
                activeTriggers.Add(gravity);
            }
        } else if (allTriggers[trigger] == camera){
            changeCamera(false);
            activeTriggers.Add(camera);
        } else if (allTriggers[trigger] == playerInput){
            flipPlayerInput(false);
            activeTriggers.Add(playerInput);
        } else if (allTriggers[trigger] == drag){
            changeDrag(false);
            activeTriggers.Add(drag);
        }
    }

    void removeRandomTrigger(){
        int trigger = Random.Range(0, activeTriggers.Count);
        if(allTriggers[trigger] == gravity){
            changeGravity(true);
            activeTriggers.Remove(gravity);
        } else if (allTriggers[trigger] == camera){
            changeCamera(true);
            activeTriggers.Remove(camera);
        } else if (allTriggers[trigger] == playerInput){
            flipPlayerInput(true);
            activeTriggers.Remove(playerInput);
        } else if (allTriggers[trigger] == drag){
            changeDrag(true);
            activeTriggers.Remove(drag);
        }
    }

    void resetTriggers(){
        changeGravity(true);
        changeCamera(true);
        changeDrag(true);
         
        flipPlayerInput(true);
    }

    void changeGravity(bool setDefault){
        if(setDefault){
            Physics.gravity = new Vector3(0, -10, 0);
        } else {
        int[] gravityVals = {0, -5, -10, 10};
        var newVal = Random.Range(0, gravityVals.Length);
        Physics.gravity = new Vector3(0, gravityVals[newVal], 0);
        Debug.Log("Gravity" + gravityVals[newVal]);
        }  
    }

    public float cameraAngle = 0f;
    void changeCamera(bool setDefault){
        if(setDefault){
            cameraAngle = 0f;
        } else {
            float[] cameraVals = {0f, 90f, 180f, 270f};
            var newVal = Random.Range(0, cameraVals.Length);
            cameraAngle = cameraVals[newVal];
            Debug.Log("Camera" + cameraVals[newVal]); 
        }
    }

    public bool reverseSameAxis = false;
    public bool reverseDiffAxis = false;
    void flipPlayerInput(bool setDefault){
         if(setDefault){
            reverseDiffAxis = false;
            reverseSameAxis = false;
        } else {
            var newVal = Random.Range(0,2);
            if(newVal == 0){
                reverseSameAxis = true;
            } else {
                reverseDiffAxis = true;
            }
            Debug.Log("Flip " + reverseSameAxis + " " + reverseDiffAxis );
        }
    }

    public void changeDrag(bool setDefault){                                 
        if(setDefault){
            rigidbody.drag = 30f;
        } else {
            rigidbody.drag = 0f;
        }
    }

}


