using UnityEngine;

public abstract class Plot<TDataPoint> where TDataPoint : IDataPoint
{
	protected GameObject plotModel;
	protected TDataPoint[] data;
	protected GameObject[] plotModelInstances;

	protected Plot(TDataPoint[] data, GameObject plotModel, Vector2 plotCenter = default)
	{
		this.data = data;
		this.plotModel = plotModel;
		plotModelInstances = new GameObject[data.Length];
	}

	public abstract void DrawPlot();
}