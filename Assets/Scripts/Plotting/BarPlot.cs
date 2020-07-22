using UnityEngine;

public class BarPlot : IPlot
{
	protected GameObject plotModel;
	protected BarDataPoint[] data;
	protected GameObject[] plotModelInstances;

	protected float barWidth;
	protected float barHeight;
	protected TwoTuple<int> binCount = new TwoTuple<int>(10, 10);
	protected Vector2 plotCenter;


	public BarPlot()
	{
		data = new BarDataPoint[5];
		data[0] = new BarDataPoint(new TwoTuple<float>(1f, 1f), 1f);
	}

	public BarPlot(BarDataPoint[] data, GameObject plotModel, float barWidth = 1, float barHeight = 1, Vector2 plotCenter = default(Vector2))
	{
		this.data = data;
		this.plotModel = plotModel;
		this.barWidth = barWidth;
		this.barHeight = barHeight;
		this.plotCenter = plotCenter;
		plotModelInstances = new GameObject[data.Length];
	}

	public BarPlot(BarDataPoint[] data, GameObject plotModel, TwoTuple<int> binCount, float barWidth = 1, float barHeight = 1, Vector2 plotCenter = default(Vector2))
	{
		this.data = data;
		this.plotModel = plotModel;
		this.barWidth = barWidth;
		this.barHeight = barHeight;
		this.binCount = binCount;
		this.plotCenter = plotCenter;
		plotModelInstances = new GameObject[data.Length];
	}


	public void DrawPlot()
	{
		float maxValue = MathFunctions.MaxBarValue(data);

		for (int posIdx = 0; posIdx < data.Length; posIdx++)
		{
			plotModelInstances[posIdx] = GameObject.Instantiate(plotModel,
																new Vector3(plotCenter.x + data[posIdx].Coords.x, 0f, plotCenter.y + data[posIdx].Coords.y),
																Quaternion.identity);
			plotModelInstances[posIdx].transform.localScale = new Vector3(barWidth, barHeight * (0.001f + data[posIdx].Value / maxValue), barWidth);

			plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].Value / maxValue, StaticValues.jet);

		}
	}
}
