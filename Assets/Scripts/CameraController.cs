using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Vector2 rotation = new Vector2 (0,0);
    // public float speed = 3f;

    public float lookSpeed = 3f;
    private Vector3 rotation = Vector3.zero;

    public void Start() {
        Camera.main.transform.localRotation = Quaternion.Euler(120f, 0, 0);
    }

    public void Update() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        rotation.z = EventManager.Instance.cameraAngle;
        transform.eulerAngles = new Vector3(0,rotation.y, rotation.z) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
