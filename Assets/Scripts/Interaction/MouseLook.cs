using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dekstop player Camera controller
/// </summary>
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject dataInspector;

	void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update()
    {
        Movement();
    }

    /// <summary>
    /// Takes the mouse movement and applies it to the desktop camera
    /// </summary>
    void Movement()
	{
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
