using UnityEngine;

/// <summary>
/// Plot class used to make a 3D scatter plot.
/// </summary>
public class ScatterPlot : Plot<ScatterDataPoint, ThreeTuple<float>>
{
	protected float modelSize;

	/// <summary>
	/// Constructor of the scatter plot class.
	/// </summary>
	/// <param name="data">ScatterDataPoints with 3D coordinates and a value.</param>
	/// <param name="plotModel">Prefab that is used to draw the data points.</param>
	/// <param name="modelSize">Scaling factor of the prefab model. Defaults to 1.</param>
	/// <param name="plotAnchor">Position in space. Defaults to (0f, 0f, 0f)</param>
	public ScatterPlot(ScatterDataPoint[] data, GameObject plotModel, float modelSize = 1f, Vector3 plotAnchor = default) : base(data, plotModel, plotAnchor)
	{
		this.modelSize = modelSize;
	}

	/// <summary>
	/// Draws the prefab of this instance at all data point coordinates.
	/// </summary>
	public override void DrawPlot()
	{
		base.DrawPlot();

		for (int posIdx = 0; posIdx < data.Length; posIdx++)
		{
			tempDataBlock = GameObject.Instantiate(plotModel,
																new Vector3(plotAnchor.x + data[posIdx].Coords.Z, plotAnchor.y + data[posIdx].Coords.Y, plotAnchor.z + data[posIdx].Coords.X),
																Quaternion.identity);
			tempDataBlock.transform.localScale = new Vector3(modelSize, modelSize, modelSize);

			//plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].Value / 3, StaticValues.jet);
			propertyBlock.SetColor("_Color", MiscUtils.GetColor(data[posIdx].Value / 3, StaticValues.jet));
			tempDataBlock.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);

			plotModelInstances[posIdx] = tempDataBlock;
		}
	}
}
