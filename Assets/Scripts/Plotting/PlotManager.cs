using UnityEngine;
using UnityEngine.XR;
using System;
using System.Collections.Generic;

public class PlotManager : MonoBehaviour
{
	public GameObject cube;
	public GameObject disk;
	public ColorMap jet;
	public DataInspector inspector;

	Dictionary<string, BarPlot> barPlotList = new Dictionary<string, BarPlot>();
	Dictionary<string, ScatterPlot> scatterPlotList = new Dictionary<string, ScatterPlot>();

	bool selected;

	void Start()
	{
		XRSettings.enabled = false;

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
		Selection();
	}


	void Selection()
	{
		if (Input.GetMouseButtonDown(0))
		{
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);
			if (hit && hitInfo.transform.gameObject.name != "Plane")
			{
				inspector.transform.position = hitInfo.transform.position + Vector3.up * (hitInfo.transform.localScale.y * 2 + 0.25f);

				foreach (KeyValuePair<string, BarPlot> barPlot in barPlotList)
				{
					selected = barPlot.Value.SelectObject(hitInfo.transform.transform.gameObject);
					if (selected)
					{
						inspector.ShowText(barPlot.Value.GetDataPoint(hitInfo.transform.transform.gameObject).ToString());
					}
				}

				foreach (KeyValuePair<string, ScatterPlot> scatterPlot in scatterPlotList)
				{
					selected = scatterPlot.Value.SelectObject(hitInfo.transform.transform.gameObject);
					if (selected)
					{
						inspector.ShowText(scatterPlot.Value.GetDataPoint(hitInfo.transform.transform.gameObject).ToString());
					}
				}

			}
		}
	}
}
