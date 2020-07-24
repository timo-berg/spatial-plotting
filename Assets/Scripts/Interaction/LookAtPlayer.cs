using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Camera desktopCamera;
    public Camera vrCamera;
    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.isVR)
        {
            playerCamera = vrCamera;
        } else {
            playerCamera = desktopCamera;
        }

        Vector3 v = playerCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(playerCamera.transform.position);
        transform.rotation = (playerCamera.transform.rotation);
    }
}
