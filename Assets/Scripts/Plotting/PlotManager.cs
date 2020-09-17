using UnityEngine;
using UnityEngine.XR;
using System;
using System.Collections.Generic;
using Valve.VR;

/// <summary>
/// Class that stores and handles the plot creation and visibility.
/// Responsible for loading data, generating the plot and selecting data points.
/// </summary>
public class PlotManager : Singleton<PlotManager>
{
	public GameObject cube;
	public GameObject disk;
	public ColorMap jet;
	public DataInspector inspector;

	Dictionary<string, BarPlot> barPlotList = new Dictionary<string, BarPlot>();
	Dictionary<string, ScatterPlot> scatterPlotList = new Dictionary<string, ScatterPlot>();

	Ray ray;
	bool selected;

	void Start()
	{
		string barFile = "IMT_sub-009_trial-1_heatmap";
		string[] barDataString = DataHandler.GetLinesFromTextResource(barFile);
		BarDataPoint[] barData = DataHandler.ParseBarPlotData(barDataString);

		barPlotList.Add("U maze", new BarPlot(barData, cube, 0.05f, barHeight: 1));
		barPlotList["U maze"].DrawPlot();

		string scatterFile = "IMT_sub-009_trial-1_scatter";
		string[] scatterDataString = DataHandler.GetLinesFromTextResource(scatterFile);
		ScatterDataPoint[] scatterData = DataHandler.ParseScatterPlotData(scatterDataString);

		scatterPlotList.Add("U maze", new ScatterPlot(scatterData, disk, 0.1f, new Vector3(0f, 0f, 0.25f)));
		scatterPlotList["U maze"].DrawPlot();
	}

	private void Update()
	{
		SelectDataPoint();
		TogglePlotVisibility();
	}

	/// <summary>
	/// Listens to left mouse click(Desktop)/index finger click (VR) and 
	/// checks whether the object that the Desktop player is looking/ VR 
	/// player pointing at is a data point. Highlight it if yes.
	/// </summary>
	void SelectDataPoint()
	{
		if (Input.GetMouseButtonDown(0) || VRInput.Instance.GetGrabPinchState())
		{
			if (PlayerManager.Instance.isVR)
			{
				ray = VRInput.Instance.GetPointingRay();
			} else
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			}


			bool hit = Physics.Raycast(ray, out RaycastHit hitInfo);
			if (hit && hitInfo.transform.gameObject.name != "Plane")
			{
				foreach (KeyValuePair<string, BarPlot> barPlot in barPlotList)
				{
					selected = barPlot.Value.PosessesObject(hitInfo.transform.transform.gameObject);
					if (selected)
					{
						inspector.ShowData(barPlot.Value.GetDataPoint(hitInfo.transform.transform.gameObject));
					}
				}

				foreach (KeyValuePair<string, ScatterPlot> scatterPlot in scatterPlotList)
				{
					selected = scatterPlot.Value.PosessesObject(hitInfo.transform.transform.gameObject);
					if (selected)
					{
						inspector.ShowData(scatterPlot.Value.GetDataPoint(hitInfo.transform.transform.gameObject));
					}
				}

			}
		}
	}

	public string GetParentPlotObject(GameObject childObject)
	{
		string plot = "none";
		foreach (KeyValuePair<string, BarPlot> barPlot in barPlotList)
		{
			selected = barPlot.Value.PosessesObject(childObject);
			if (selected)
			{
				plot = barPlot.Key;
			}
		}

		foreach (KeyValuePair<string, ScatterPlot> scatterPlot in scatterPlotList)
		{
			selected = scatterPlot.Value.PosessesObject(childObject);
			if (selected)
			{
				plot = scatterPlot.Key;
			}
		}
		return plot;
	}

	public string GetParentPlotDataPoint(ScatterDataPoint datapoint)
	{
		string plot = "none";
		foreach (KeyValuePair<string, ScatterPlot> scatterPlot in scatterPlotList)
		{
			selected = scatterPlot.Value.PosessesDataPoint(datapoint);
			if (selected)
			{
				plot = scatterPlot.Key;
			}
		}
		return plot;
	}

	public string GetParentPlotDataPoint(BarDataPoint datapoint)
	{
		string plot = "none";
		foreach (KeyValuePair<string, BarPlot> barPlot in barPlotList)
		{
			selected = barPlot.Value.PosessesDataPoint(datapoint);
			if (selected)
			{
				plot = barPlot.Key;
			}
		}

		return plot;
	}

	void TogglePlotVisibility()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			barPlotList["U maze"].TogglePlot();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			scatterPlotList["U maze"].TogglePlot();
		}
	}
}
