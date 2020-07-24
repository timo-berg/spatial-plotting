using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Valve.VR;

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

	private void Update()
	{
        UpdateLength();
	}

    private void UpdateLength()
	{
        lineRenderer.SetPosition(0, pointingController.transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
	}

    private Vector3 CalculateEnd()
	{
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        if (hit.collider)
            endPosition = hit.point;

        return endPosition;
	}

    private RaycastHit CreateForwardRaycast()
	{
		Ray ray = GetPointingRay();

		Physics.Raycast(ray, out RaycastHit hit, defaultLength);
        return hit;
	}

    private Vector3 DefaultEnd(float length)
	{
        return pointingController.transform.position + (pointingController.transform.forward * length);
	}

	public Ray GetPointingRay()
    {
        return new Ray(pointingController.transform.position, 
                       pointingController.transform.TransformDirection(Vector3.forward));
    }

    public bool GetGrabPinchState()
	{
        return SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.Any);
    }

}
