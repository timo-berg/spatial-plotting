using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject dataInspector;

    GameObject previousSelection;
    GameObject currentSelection;

	void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        previousSelection = null;

    }

	void Update()
    {
        Movement();
        //Selection();
    }

    void Movement()
	{
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void Selection()
	{
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && hitInfo.transform.gameObject.name != "Plane")
            {

                Debug.Log(hitInfo.transform.gameObject.name);
                currentSelection = hitInfo.transform.transform.gameObject;
                dataInspector.transform.position = hitInfo.transform.position + Vector3.up * (hitInfo.transform.localScale.y*2 + 0.25f);
                var outline = currentSelection.AddComponent<Outline>();
                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.yellow;
                outline.OutlineWidth = 5f;

                if(previousSelection != null)
				{
                    var oldOutline = previousSelection.GetComponent<Outline>();
                    Destroy(oldOutline);
				}

                previousSelection = currentSelection;
            }
        }
    }
}
