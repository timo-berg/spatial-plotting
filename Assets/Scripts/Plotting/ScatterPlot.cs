using UnityEngine;

public class ScatterPlot : Plot<ScatterDataPoint>
{
	protected Vector3 plotCenter;
	protected float modelSize;

	public ScatterPlot(ScatterDataPoint[] data, GameObject plotModel, float modelSize = 1f, Vector3 plotCenter = default) : base(data, plotModel)
	{
		this.plotCenter = plotCenter;
		this.modelSize = modelSize;
	}

	public override void DrawPlot()
	{
		for (int posIdx = 0; posIdx < data.Length; posIdx++)
		{
			plotModelInstances[posIdx] = GameObject.Instantiate(plotModel,
																new Vector3(plotCenter.x + data[posIdx].Coords.Z, plotCenter.y + data[posIdx].Coords.Y, plotCenter.z + data[posIdx].Coords.X),
																Quaternion.identity);
			plotModelInstances[posIdx].transform.localScale = new Vector3(modelSize, modelSize, modelSize);

			plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].Value / 3, StaticValues.jet);

		}
	}
}
