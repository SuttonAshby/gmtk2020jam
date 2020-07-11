using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedMoveController : MonoBehaviour
{
   public float defaultSpeed = 6.0f;
  public float speed = 6.0f;
  public float sprintSpeed = 50.0f;
  public float jumpSpeed = 8.0f;
  public float gravity = 20.0f;
  public float rotationSpeed = 60f;

  private Vector3 moveDirection = Vector3.zero;
  private Rigidbody rb;
  public bool isGrounded = false;
  public float forwardVelocity;

//   public Animator animator;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    speed = defaultSpeed;
    // animator = GetComponent<Animator>();
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


  void Update()
  {
    float vertical = Input.GetAxis("Vertical");
    float horizontal = Input.GetAxis("Horizontal");

    if (vertical < 0)
    {
      horizontal = -horizontal;
    }

    transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

    var locVel = transform.InverseTransformDirection(rb.velocity);
    locVel.z = -vertical * speed;

    if (isGrounded && Input.GetButton("Jump"))
    {
      locVel.y = jumpSpeed - (gravity * Time.deltaTime);
      isGrounded = false;
    }


    // animator.SetFloat("X", Mathf.Clamp(value: horizontal, min: -0.5f, max: 0.5f));
    // animator.SetFloat("Y", Mathf.Clamp(value: vertical, min: -0.5f, max: 0.5f));
    if (Input.GetButton("Fire1"))
    {
      speed = Mathf.Clamp(value: speed + 0.2f, min: 0.0f, max: sprintSpeed);
    //   animator.SetFloat("X", Mathf.Clamp(value: horizontal, min: -1.0f, max: 1.0f));
    //   animator.SetFloat("Y", Mathf.Clamp(value: vertical, min: -1.0f, max: 1.0f));
    }

    else
    {
      speed = defaultSpeed;
    }

    rb.velocity = transform.TransformDirection(locVel);
        forwardVelocity = -locVel.z;

  }
}