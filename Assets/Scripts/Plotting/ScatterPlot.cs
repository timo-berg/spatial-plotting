using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterPlot 
{
    protected GameObject plotModel;
    protected ScatterDataPoint[] data;
    protected GameObject[] plotModelInstances;

    protected Vector3 plotCenter;
    protected float modelSize;

    public ScatterPlot()
    {
        data = new ScatterDataPoint[5];
        data[0] = new ScatterDataPoint(new ThreeCoords(1f, 1f, 1f), 1f);
    }

    public ScatterPlot(ScatterDataPoint[] data, GameObject plotModel, float modelSize = 1f, Vector3 plotCenter = default(Vector3))
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
                                                                new Vector3(plotCenter.x + data[posIdx].coords.z, plotCenter.y + data[posIdx].coords.y, plotCenter.z + data[posIdx].coords.x),
                                                                Quaternion.identity);
            plotModelInstances[posIdx].transform.localScale = new Vector3(modelSize, modelSize, modelSize);

            //plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].value / 1200, StaticValues.jet);

        }
    }
}
