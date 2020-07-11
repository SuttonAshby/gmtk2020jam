using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float sensitivity = 2f;
    public float moveSpeed = 10f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(Input.GetKey(KeyCode.W)) {
            // transform.position += transform.forward / 2;
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.z = moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
            // rb.velocity = new Vector3(0,0,1f/Time.fixedDeltaTime)/4;
        }
        if(Input.GetKey(KeyCode.S)) {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.z = -moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
            // transform.position += -transform.forward / 2;
        }
        if(Input.GetKey(KeyCode.A)) {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.x = -moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
            // transform.position += -transform.right / 2;
        }
        if(Input.GetKey(KeyCode.D)) {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.x = moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
            // transform.position += transform.right / 2;
        }

        //FPS camera
        // rotX = Input.GetAxis ("Mouse X") + sensitivity;
        // rotY = Input.GetAxis ("mouse Y") + sensitivity;   
        // transform.Rotate (0, rotX, 0);

    }
}
