using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 4f;
    public float flySpeed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Jump");
        float z = Input.GetAxis("Vertical");

        Vector3 move = walkSpeed * (transform.right * x + transform.forward * z) + flySpeed * Vector3.up * y;

        controller.Move(move * Time.deltaTime);
    }
}
