using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Valve.VR;

/// <summary>
/// Class that handles all VR input such as pointing clicking etc.
/// </summary>
public class VRInput : Singleton<VRInput>
{
    public GameObject pointingController;

    public float defaultLength = 3f;
    private LineRenderer lineRenderer = null;

    protected override void Awake()
	{
        base.Awake();
        lineRenderer = GetComponent<LineRenderer>();
    }

	private void Start()
	{
	    if (!PlayerManager.Instance.isVR)
		{
            lineRenderer.enabled = false;
		}
	}

	private void Update()
	{
        UpdateLength();
	}

    /// <summary>
    /// Update the ray length.
    /// </summary>
    private void UpdateLength()
	{
        lineRenderer.SetPosition(0, pointingController.transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
	}

    /// <summary>
    /// Calculates end position of pointing ray.
    /// If the pointing ray hit an object the hit location is the end
    /// otherwise the ray defaults to its default length.
    /// </summary>
    private Vector3 CalculateEnd()
	{
        Ray ray = GetPointingRay();

        Physics.Raycast(ray, out RaycastHit hit, defaultLength);
    
        Vector3 endPosition = pointingController.transform.position + (pointingController.transform.forward * defaultLength);

        if (hit.collider)
            endPosition = hit.point;

        return endPosition;
	}

    /// <summary>
    /// Returns the current pointing ray
    /// </summary>
 	public Ray GetPointingRay()
    {
        return new Ray(pointingController.transform.position, 
                       pointingController.transform.TransformDirection(Vector3.forward));
    }

    /// <summary>
    /// Returns true if any controller is currently pinching.
    /// (index finger button on htc controller)
    /// </summary>
    public bool GetGrabPinchState()
	{
        return SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.Any);
    }

}
