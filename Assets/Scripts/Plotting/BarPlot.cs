using UnityEngine;

public class BarPlot : Plot<BarDataPoint>
{
	protected Vector2 plotCenter;
	protected float barWidth;
	protected float barHeight;
	protected TwoTuple<int> binCount = new TwoTuple<int>(10, 10);


	public BarPlot(BarDataPoint[] data, GameObject plotModel, float barWidth = 1, float barHeight = 1, Vector2 plotCenter = default) : base(data, plotModel) 
	{
		this.barWidth = barWidth;
		this.barHeight = barHeight;
		this.plotCenter = plotCenter;
	}

	public BarPlot(BarDataPoint[] data, GameObject plotModel, TwoTuple<int> binCount, float barWidth = 1, float barHeight = 1, Vector2 plotCenter = default) : base(data, plotModel)
	{
		this.barWidth = barWidth;
		this.barHeight = barHeight;
		this.binCount = binCount;
		this.plotCenter = plotCenter;
	}


	public override void DrawPlot()
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
