using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListener : MonoBehaviour
{
    // Start is called before the first frame update

    bool turnOn = true;


    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(turnOn && GameManager.Instance.playedTime == 2f){
            turnOn = false;
            // AudioListener al = this.gameObject.addComponent<AudioListener>() as AudioListener;
        }
    }
}
