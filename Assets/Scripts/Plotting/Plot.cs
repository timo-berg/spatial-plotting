using UnityEngine;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

/// <summary>
/// Generic abstract class from which all Plot classes inherit from.
/// </summary>
/// <typeparam name="TDataPoint">Each child class is associated with single data type</typeparam>
public abstract class Plot<TDataPoint, TTuple> where TDataPoint : IDataPoint<TTuple>
{
	protected GameObject plotModel;
	protected TDataPoint[] data;
	public GameObject[] plotModelInstances;
	protected Vector3 plotAnchor;

	protected GameObject currentSelection;
	protected GameObject previousSelection;

	protected MaterialPropertyBlock propertyBlock;
	protected GameObject tempDataBlock;

	protected bool isVisible; // { protected set; get; }

	/// <summary>
	/// Constructor of the abstract plot class
	/// </summary>
	/// <param name="data">Plot data of a struct that implements the IDataPoint interface</param>
	/// <param name="plotModel">Prefab that is used to draw the data</param>
	/// <param name="plotAnchor">Position in space. Defaults to (0f, 0f, 0f)</param>
	protected Plot(TDataPoint[] data, GameObject plotModel, Vector3 plotAnchor = default)
	{
		this.data = data;
		this.plotModel = plotModel;
		this.plotAnchor = plotAnchor;
		plotModelInstances = new GameObject[data.Length];
		currentSelection = null;
		previousSelection = null;
		propertyBlock = new MaterialPropertyBlock();
		isVisible = false;
	}

	public virtual void DrawPlot() 
	{
		isVisible = true;
	}
	

	/// <summary>
	/// Returns the data point for the passed GameObject.
	/// </summary>
	/// <remarks>
	/// If the GameObject isn't part of the plot it returns the default value
	/// of the data point. Use SelectObject() first to check whether the passed
	/// GameObject is actually part of the plot.
	/// </remarks>
	public virtual TDataPoint GetDataPoint(GameObject selection)
	{
		int matchIndex = Array.FindIndex(plotModelInstances, element => element == selection);
		if (matchIndex == -1)
		{
			return default;
		} else {
			return data[matchIndex];
		}
	}

	/// <summary>
	/// Turns on the plot visibility
	/// </summary>
	public virtual void ShowPlot()
	{
		isVisible = true;

		foreach (GameObject plotElement in plotModelInstances)
		{
			plotElement.SetActive(true);
		}
	}

	/// <summary>
	/// Turns off the plot visibility
	/// </summary>
	public virtual void HidePlot()
	{
		isVisible = false;

		foreach (GameObject plotElement in plotModelInstances)
		{
			plotElement.SetActive(false);
		}
	}

	/// <summary>
	/// Toggles the plot visibility
	/// </summary>
	public virtual void TogglePlot()
	{
		if(isVisible)
		{
			HidePlot();
		} else
		{
			ShowPlot();
		}

	}

	/// <summary>
	/// Returns true if the passed GameObject is part of that plot and false if it isn"t.
	/// </summary>
	public virtual bool PosessesObject(GameObject selection)
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

		return (match != null) ? true : false;

	}

	public virtual bool PosessesDataPoint(TDataPoint datapoint)
	{
		return data.Contains(datapoint);
	}
}