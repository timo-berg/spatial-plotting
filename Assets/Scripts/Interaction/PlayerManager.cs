using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// Manages the plaers: Activated/Deactivates the VR/Desktop player
/// depending on whether an HMD is plugged in or not
/// </summary>
public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject VRplayer;
    public GameObject DesktopPlayer;

    public bool isVR;

    void Start()
    {
        if (XRSettings.enabled && XRSettings.isDeviceActive)
        {
            VRplayer.SetActive(true);
            DesktopPlayer.SetActive(false);
            Debug.Log("Using VR");
            isVR = true;
        } else
        {
            VRplayer.SetActive(false);
            DesktopPlayer.SetActive(true);
            isVR = false;
            XRSettings.enabled = false;
            Debug.Log("Using Desktop");
        }
    }

    void Update()
    {
        
    }
}
