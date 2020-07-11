using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public bool inTrigger = false;
    public bool isActive = false;
    public Renderer rend;
    Color defaultColor;

    GameObject cat;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = rend.material.color;
        defaultColor.a = 0f;

        cat = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        SetCatActive(false);
        // Debug.Log(cat);
    }

    void OnTriggerEnter(){
        if(isActive){
            isActive = false;
            GoalController.Instance.locationReached = true;            
        }
        inTrigger = true;
    }

    void OnTriggerExit(){
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger){
            Color color = rend.material.color;
                color.r = 0f; 
                color.g = 1f; //green
                color.b = 0f;
                color.a = 1f;
                rend.material.color = color;
                rend.material.SetColor("_EmissionColor", color);
        } else {
            rend.material.color = defaultColor;
            rend.material.SetColor("_EmissionColor", defaultColor);
        }

        if(isActive){
            //cat visible
            SetCatActive(true);
        } else {
            //cat invisible
            SetCatActive(false);
        }

    }

    void SetCatActive(bool active){
        if(active){
            cat.GetComponent<SkinnedMeshRenderer>().enabled = true;
        } else {
            cat.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }

}
