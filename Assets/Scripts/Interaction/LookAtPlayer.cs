using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = playerCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(playerCamera.transform.position);
        transform.rotation = (playerCamera.transform.rotation);
    }
}
