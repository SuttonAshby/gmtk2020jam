using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float sensitivity = 2f;
    public float moveSpeed = 10f;
    public Rigidbody rb;

    public float gravity = 15f;

    public bool isGrounded = false;

    public float jumpSpeed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //to check if jumping is valid
        if (collision.gameObject.tag == "Ground")
        {
            // Debug.Log("tagged Ground");
            isGrounded = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        if(vertical > 0) {
            // transform.position += transform.forward / 2;
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.z = moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
            // rb.velocity = new Vector3(0,0,1f/Time.fixedDeltaTime)/4;
        } else if(vertical < 0) {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.z = -moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
        }

        if(horizontal < 0) {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.x = -moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
        } else if(horizontal > 0){
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.x = moveSpeed;
            rb.velocity = transform.TransformDirection(locVel);
        }

        if (isGrounded && Input.GetButton("Jump"))
        {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.y = jumpSpeed - (gravity * Time.deltaTime);
            isGrounded = false;
        }

        // if(Input.GetKey(KeyCode.W)) {
        //     var locVel = transform.InverseTransformDirection(rb.velocity);
        //     locVel.z = moveSpeed;
        //     rb.velocity = transform.TransformDirection(locVel);
        // }
        // if(Input.GetKey(KeyCode.S)) {
        //     var locVel = transform.InverseTransformDirection(rb.velocity);
        //     locVel.z = -moveSpeed;
        //     rb.velocity = transform.TransformDirection(locVel);
        // }
        // if(Input.GetKey(KeyCode.A)) {
        //     var locVel = transform.InverseTransformDirection(rb.velocity);
        //     locVel.x = -moveSpeed;
        //     rb.velocity = transform.TransformDirection(locVel);
        // }
        // if(Input.GetKey(KeyCode.D)) {
        //     var locVel = transform.InverseTransformDirection(rb.velocity);
        //     locVel.x = moveSpeed;
        //     rb.velocity = transform.TransformDirection(locVel);
        // }
    }
}
