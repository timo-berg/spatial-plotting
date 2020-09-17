using UnityEngine;
using System;
using System.Text.RegularExpressions;

/// <summary>
/// Overloaded Plot class to generate a bivariate bar plot
/// </summary>
public class BarPlot : Plot<BarDataPoint, TwoTuple<float>>
{
	protected float barWidth;
	protected float barHeight;
	protected TwoTuple<int> binCount = new TwoTuple<int>(10, 10);


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
		base.DrawPlot();

		float maxValue = MathFunctions.MaxBarValue<BarDataPoint, TwoTuple<float>>(data);

		for (int posIdx = 0; posIdx < data.Length; posIdx++)
		{
			tempDataBlock = GameObject.Instantiate(plotModel,
												plotAnchor + new Vector3(data[posIdx].Coords.X, 0f, data[posIdx].Coords.Y),
												Quaternion.identity);

			tempDataBlock.transform.localScale = new Vector3(barWidth, barHeight * (0.001f + data[posIdx].Value / maxValue), barWidth);

			propertyBlock.SetColor("_Color", MiscUtils.GetColor(data[posIdx].Value / maxValue, StaticValues.jet));
			tempDataBlock.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);

			plotModelInstances[posIdx] = tempDataBlock;
		}
	}
}
