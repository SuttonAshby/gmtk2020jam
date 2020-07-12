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
    public string big = "changeSizeBig";
    public string small = "changeSizeSmall";
    public string playerInput = "flipPlayerInput";
    public string teleport = "movePlayer";

    public Rigidbody playerRb;

    public float minEventTimer = 10f;
    public float maxEventTimer = 25f;
    public float nextEventTimeLeft = 10f;
    bool timerActive = true;

    List<string> activeTriggers = new List<string>();

    List<string> allTriggers = new List<string>();

    private void Start () {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();

        allTriggers.Add(gravity);
        allTriggers.Add(camera);
        allTriggers.Add(drag); 
        allTriggers.Add(big);
        allTriggers.Add(small);
        allTriggers.Add(playerInput);
        allTriggers.Add(teleport);
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
        if(GameManager.Instance.isPlaying){
            if(nextEventTimeLeft > 0 && timerActive == true){
                nextEventTimeLeft -= Time.deltaTime;
            } else {
                triggerRandomEffect();
            }
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
            if(!activeTriggers.Contains(camera)){
                activeTriggers.Add(camera);
            }
        } else if (allTriggers[trigger] == playerInput){
            flipPlayerInput(false);
            if(!activeTriggers.Contains(playerInput)){
                activeTriggers.Add(playerInput);
            }
        } else if (allTriggers[trigger] == drag){
            changeDrag(false);
            if(!activeTriggers.Contains(drag)){
                activeTriggers.Add(drag);
            }
        } else if (allTriggers[trigger] == big){
            changeSizeBig(false);
            if(!activeTriggers.Contains(big)){
                activeTriggers.Add(big);
            }
        } else if (allTriggers[trigger] == small){
            changeSizeSmall(false);
            if(!activeTriggers.Contains(small)){
                activeTriggers.Add(small);
            }
        } else if (allTriggers[trigger] == teleport){
            movePlayer(false);
            if(!activeTriggers.Contains(teleport)){
                activeTriggers.Add(teleport);
            }
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
        } else if (allTriggers[trigger] == big){
            changeSizeBig(true);
            activeTriggers.Remove(big);
        } else if (allTriggers[trigger] == small){
            changeSizeSmall(true);
            activeTriggers.Remove(small);
        } else if (allTriggers[trigger] == teleport){
            movePlayer(true);
            activeTriggers.Remove(teleport);
        }
    }

    void resetTriggers(){
        changeGravity(true);
        changeCamera(true);
        changeDrag(true);     
        flipPlayerInput(true);
        changeSizeBig(true);
        changeSizeSmall(true);
        movePlayer(true);
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
            playerRb.drag = 30f;
        } else {
            playerRb.drag = 0f;
            Debug.Log("Drag");
        }
    }

    public void changeSizeBig(bool setDefault){
        if(setDefault){
            playerRb.transform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            playerRb.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
            Debug.Log("Big");
        }
    }

    public void changeSizeSmall(bool setDefault){
        if(setDefault){
            playerRb.transform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            playerRb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Debug.Log("Small");
        }
    }

    //public Transform teleportTarget; 
    void movePlayer(bool setDefault){
        if(setDefault){
            playerRb.transform.position == false;
        } else { 
            playerRb.transform.position = new Vector3(pox.x -300, pos.y, pos.z);
            Debug.Log("Teleport");
      }
    }
}


