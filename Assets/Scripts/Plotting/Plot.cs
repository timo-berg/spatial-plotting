using UnityEngine;

/// <summary>
/// Generic abstract class from which all Plot classes inherit from.
/// </summary>
/// <typeparam name="TDataPoint">Each child class is associated with single data type</typeparam>
public abstract class Plot<TDataPoint> where TDataPoint : IDataPoint
{
	protected GameObject plotModel;
	protected TDataPoint[] data;
	public GameObject[] plotModelInstances;
	protected Vector3 plotAnchor;

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
	}

	public abstract void DrawPlot();
}