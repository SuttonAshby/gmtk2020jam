using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public static GoalController Instance {get; private set; }

    public GameObject TriggerAreaOne;
    public GameObject TriggerAreaTwo;
    public GameObject TriggerAreaThree;
    public GameObject TriggerAreaFour;
    public GameObject TriggerAreaFive;

    public AudioSource audio;
    public AudioClip locationChanged;
    public GameObject TriggerAreaSix;
    private TriggerPad triggerPadOne;
    private TriggerPad triggerPadTwo;
    private TriggerPad triggerPadThree;
    private TriggerPad triggerPadFour;
    private TriggerPad triggerPadFive;
    private TriggerPad triggerPadSix;

	private void Awake () {
        //Initiate singleton
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
    // Start is called before the first frame update

    private void Start() {
        triggerPadOne = TriggerAreaOne.gameObject.GetComponent<TriggerPad>();
        triggerPadTwo = TriggerAreaTwo.gameObject.GetComponent<TriggerPad>();
        triggerPadThree = TriggerAreaThree.gameObject.GetComponent<TriggerPad>();
        triggerPadFour = TriggerAreaFour.gameObject.GetComponent<TriggerPad>();
        triggerPadFive = TriggerAreaFive.gameObject.GetComponent<TriggerPad>();
        triggerPadSix = TriggerAreaSix.gameObject.GetComponent<TriggerPad>();

        //TODO hide console cat
        setNewLocation();
    }
    
    public bool locationReached;
    public int timesFound = 0;

    // Update is called once per frame
    void Update(){
        if(locationReached && timesFound < 9){
            locationReached = false;
            timesFound++;
            setNewLocation();
        } else {
            MiniUIManager.Instance.showPlayAgain();
        }
    }

    void setNewLocation(){
        var chance = Random.Range(0, 120);
        if(chance < 20){
            triggerPadOne.isActive = true;
        } else if( 20 < chance && chance < 40){
            triggerPadTwo.isActive = true;
        } else if( 40 < chance && chance < 60){
            triggerPadThree.isActive = true;
        } else if( 60 < chance && chance < 80){
            triggerPadFour.isActive = true;
        } else if( 80 < chance && chance < 100){
            triggerPadFive.isActive = true;
        } else {
            triggerPadSix.isActive = true;
        }
        playLocationChanged();
    }

    public void playLocationChanged(){
        audio.clip = locationChanged;
        audio.Play();
    }

}
