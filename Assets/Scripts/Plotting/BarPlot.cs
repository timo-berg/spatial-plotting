using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BarPlot
{
    protected GameObject plotModel;
    protected BarDataPoint[] data; 
    protected GameObject[] plotModelInstances;

    protected float barWidth;
    protected IntTuple binCount = new IntTuple(10,10);
    protected Vector2 plotCenter;


    public BarPlot()
    {
        data = new BarDataPoint[5];
        data[0] = new BarDataPoint(new TwoCoords(1f, 1f), 1f);
    }

    public BarPlot(BarDataPoint[] data, GameObject plotModel, float barWidth = 1, Vector2 plotCenter = default(Vector2))
    {
        this.data = data;
        this.plotModel = plotModel;
        this.barWidth = barWidth;
        this.plotCenter = plotCenter;
        plotModelInstances = new GameObject[data.Length];
    }

    public BarPlot(BarDataPoint[] data, GameObject plotModel, IntTuple binCount, float barWidth = 1, Vector2 plotCenter = default(Vector2))
    {
        this.data = data;
        this.plotModel = plotModel;
        this.barWidth = barWidth;
        this.binCount = binCount;
        this.plotCenter = plotCenter;
        plotModelInstances = new GameObject[data.Length];
    }


    public void DrawPlot()
    {
        for (int posIdx = 0; posIdx < data.Length; posIdx++)
        {
            plotModelInstances[posIdx] = GameObject.Instantiate(plotModel, 
                                                                new Vector3(plotCenter.x + data[posIdx].coords.x,0f,plotCenter.y + data[posIdx].coords.y), 
                                                                Quaternion.identity);
            plotModelInstances[posIdx].transform.localScale = new Vector3(barWidth, 0.001f + data[posIdx].value/1200, barWidth);

            plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].value/1200, StaticValues.jet);
            
        }
	}
}
