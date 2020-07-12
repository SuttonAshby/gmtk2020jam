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
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        

        var locVel = transform.InverseTransformDirection(rb.velocity);

        if(EventManager.Instance.reverseSameAxis && !EventManager.Instance.reverseDiffAxis){
            if(vertical < 0) {
                locVel.z = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(vertical > 0) {
                locVel.z = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }

            if(horizontal > 0) {
                locVel.x = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(horizontal < 0){
                locVel.x = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }
        } else if(!EventManager.Instance.reverseSameAxis && EventManager.Instance.reverseDiffAxis){
            if(horizontal > 0) {
                locVel.z = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(horizontal < 0) {
                locVel.z = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }

            if(vertical < 0) {
                locVel.x = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(vertical > 0){
                locVel.x = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }
        } else if(EventManager.Instance.reverseSameAxis && EventManager.Instance.reverseDiffAxis){
            if(horizontal < 0) {
                locVel.z = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(horizontal > 0) {
                locVel.z = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }

            if(vertical > 0) {
                locVel.x = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(vertical < 0){
                locVel.x = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }
        } else {
            if(vertical > 0) {
                locVel.z = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(vertical < 0) {
                locVel.z = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }

            if(horizontal < 0) {
                locVel.x = -moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            } else if(horizontal > 0){
                locVel.x = moveSpeed;
                rb.velocity = transform.TransformDirection(locVel);
            }
        }



        if (isGrounded && Input.GetButton("Jump"))
        {
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
