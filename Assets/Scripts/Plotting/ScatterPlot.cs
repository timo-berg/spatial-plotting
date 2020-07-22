using UnityEngine;

public class ScatterPlot : IPlot
{
	protected GameObject plotModel;
	protected ScatterDataPoint[] data;
	protected GameObject[] plotModelInstances;

	protected Vector3 plotCenter;
	protected float modelSize;

	public ScatterPlot()
	{
		data = new ScatterDataPoint[5];
		data[0] = new ScatterDataPoint(new ThreeTuple<float>(1f, 1f, 1f), 1f);
	}

	public ScatterPlot(ScatterDataPoint[] data, GameObject plotModel, float modelSize = 1f, Vector3 plotCenter = default)
	{
		this.data = data;
		this.plotModel = plotModel;
		this.plotCenter = plotCenter;
		this.modelSize = modelSize;
		plotModelInstances = new GameObject[data.Length];
	}

	public void DrawPlot()
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
