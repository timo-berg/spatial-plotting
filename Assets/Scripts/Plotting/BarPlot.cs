using UnityEngine;
using System;
using System.Text.RegularExpressions;

/// <summary>
/// Overloaded Plot class to generate a bivariate bar plot
/// </summary>
public class BarPlot : Plot<BarDataPoint>
{
	protected float barWidth;
	protected float barHeight;
	protected TwoTuple<int> binCount = new TwoTuple<int>(10, 10);

	GameObject currentSelection;
	GameObject previousSelection;

	/// <summary>
	/// Constructor for the bar plot class
	/// </summary>
	/// <param name="data">Pre-binned data array with data points that each represent one bar</param>
	/// <param name="plotModel">Prefab that is used for the bars. A simple cube is recommended</param>
	/// <param name="barWidth">Width of the bar model as a scaling factor.Default is 1 </param>
	/// <param name="barHeight">Height of the bar model as a scaling factor. Default is 1 </param>
	/// <param name="plotAnchor">Position in space. Defaults to (0f, 0f, 0f)</param>
	/// <param name="binCount">PLACEHOLDER PARAMETER</param>
	public BarPlot(BarDataPoint[] data, GameObject plotModel, float barWidth = 1, float barHeight = 1, Vector3 plotAnchor = default, TwoTuple<int> binCount = default) : base(data, plotModel, plotAnchor)
	{
		this.barWidth = barWidth;
		this.barHeight = barHeight;
		this.binCount = binCount;
		currentSelection = null;
		previousSelection = null;
	}

	/// <summary>
	/// Draws bars at the position of the coordinates of the BarDataPoints.
	/// </summary>
	/// <remarks>
	/// Height and color are normalized such that the largest value has an height of 1
	/// and the last value of the colormap.
	/// Scaling of the bar plot can be achieved via the barHeight property
	/// </remarks>
	public override void DrawPlot()
	{
		float maxValue = MathFunctions.MaxBarValue(data);

		for (int posIdx = 0; posIdx < data.Length; posIdx++)
		{
			plotModelInstances[posIdx] = GameObject.Instantiate(plotModel,
																plotAnchor + new Vector3(data[posIdx].Coords.x, 0f, data[posIdx].Coords.y),
																Quaternion.identity);
			plotModelInstances[posIdx].transform.localScale = new Vector3(barWidth, barHeight * (0.001f + data[posIdx].Value / maxValue), barWidth);

			plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].Value / maxValue, StaticValues.jet);
		}
	}

	public void SelectObject(GameObject selection)
	{
		var match = Array.Find(plotModelInstances, element => element == selection);
		if (match != null)
		{
			var outline = match.AddComponent<Outline>();
			outline.OutlineMode = Outline.Mode.OutlineAll;
			outline.OutlineColor = Color.yellow;
			outline.OutlineWidth = 5f;
		}

		currentSelection = match;
		if (previousSelection != null)
		{
			var oldOutline = previousSelection.GetComponent<Outline>();
			UnityEngine.Object.Destroy(oldOutline);
		}
		previousSelection = currentSelection;
	}

	public BarDataPoint GetDataPoint(GameObject selection)
	{
		int matchIndex = Array.FindIndex(plotModelInstances, element => element == selection);
		return data[matchIndex];
	}
}
