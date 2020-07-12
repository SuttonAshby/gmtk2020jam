using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventFunctions: MonoBehaviour
{

    public GameObject; //Add each object that is changed by each event.
    public GameObject;
    public GameObject;
    public GameObject;
    public GameObject;

    //Start is called before the first frame update

    void Start() {
        //example:
        // if (respawn == null)
        //     respawn = GameObject.FindWithTag("Respawn");
    
    //Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
    }

    //Update is called once per frame
    
    void Update() {
        if(rb.drag != EventManager.instance.drag) {
            //?? rb.drag = 50 (or whatever number works)
        } 
    }
}



//.....OR.....



//Friction 1
public void causeDrag(add the tag for the object?) {
    if(rb.drag != EventManager.instance.drag) {
            rb.drag = 50 (or whatever number works for slippiness)
    }
}



//...Or Friction 2
//Set collider to act like ice while function is called:
//   collider.material.dynamicFriction = 0;
//   collider.material.staticFriction = 0;


