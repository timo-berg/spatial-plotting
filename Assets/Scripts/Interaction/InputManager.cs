using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class InputManager : Singleton<InputManager>
{
    public GameObject pointingController;

    public GameObject Radio1;
    public GameObject Radio2;
    public GameObject Radio3;

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
        ClickListener();
    }


    void ClickListener()
    {
        Ray ray = default;
        if (Input.GetMouseButtonDown(0) || VRInput.Instance.GetGrabPinchState())
        {
            if (PlayerManager.Instance.isVR)
            {
                ray = VRInput.Instance.GetPointingRay();
            } else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
        }

        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo);
        if (hit && hitInfo.transform.parent != null)
		{
            if (hitInfo.transform.parent.ToString().Contains("ScatterPlots") )
			{
                if (hitInfo.transform.gameObject.name.Contains("1"))
                {
                    PlotManager.Instance.TogglePlotVisibility("U maze scatter 1");
                    hitInfo.transform.gameObject.GetComponent<Toggle>().isOn = !hitInfo.transform.gameObject.GetComponent<Toggle>().isOn;
                }
                if (hitInfo.transform.gameObject.name.Contains("2"))
                {
                    PlotManager.Instance.TogglePlotVisibility("U maze scatter 2");
                    hitInfo.transform.gameObject.GetComponent<Toggle>().isOn = !hitInfo.transform.gameObject.GetComponent<Toggle>().isOn;
                }
                if (hitInfo.transform.gameObject.name.Contains("3"))
                {
                    PlotManager.Instance.TogglePlotVisibility("U maze scatter 3");
                    hitInfo.transform.gameObject.GetComponent<Toggle>().isOn = !hitInfo.transform.gameObject.GetComponent<Toggle>().isOn;
                }

            }
            if (hitInfo.transform.parent.ToString().Contains("BarPlots"))
			{
                if (hitInfo.transform.gameObject.name.Contains("1"))
				{
                    PlotManager.Instance.ShowPlot("U maze bar 1");
                    PlotManager.Instance.HidePlot("U maze bar 2");
                    PlotManager.Instance.HidePlot("U maze bar 3");
                    Radio1.GetComponent<Toggle>().isOn = true;
                    Radio2.GetComponent<Toggle>().isOn = false;
                    Radio3.GetComponent<Toggle>().isOn = false;
                }
                if (hitInfo.transform.gameObject.name.Contains("2"))
                {
                    PlotManager.Instance.HidePlot("U maze bar 1");
                    PlotManager.Instance.ShowPlot("U maze bar 2");
                    PlotManager.Instance.HidePlot("U maze bar 3");
                    Radio1.GetComponent<Toggle>().isOn = false;
                    Radio2.GetComponent<Toggle>().isOn = true;
                    Radio3.GetComponent<Toggle>().isOn = false;
                }
                if (hitInfo.transform.gameObject.name.Contains("3"))
                {
                    PlotManager.Instance.HidePlot("U maze bar 1");
                    PlotManager.Instance.HidePlot("U maze bar 2");
                    PlotManager.Instance.ShowPlot("U maze bar 3");
                    Radio1.GetComponent<Toggle>().isOn = false;
                    Radio2.GetComponent<Toggle>().isOn = false;
                    Radio3.GetComponent<Toggle>().isOn = true;
                }
            }
        }
    }

    

    /// <summary>
    /// Update the ray length.
    /// </summary>
    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, pointingController.transform.position);
        lineRenderer.SetPosition(1, CalculateRayEnd());
    }

    /// <summary>
    /// Calculates end position of pointing ray.
    /// If the pointing ray hit an object the hit location is the end
    /// otherwise the ray defaults to its default length.
    /// </summary>
    private Vector3 CalculateRayEnd()
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
