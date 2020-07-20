﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPlot : Plot
{
    private GameObject parentObject;
    public BarPlot()
    {
        data = new Vector3[5];
        data[0] = new Vector3(1f, 1f, 1f);
        Debug.Log("Bar Plot instantiated with default data.");
    }

    public BarPlot(Vector3[] newData, GameObject newModel) : base(newData, newModel)
    {
        Debug.Log("Bar Plot instantiated with custom data and model.");
        plotModelInstances = new GameObject[data.Length];
    }

    public void DrawPlot()
    {
        for (int posIdx = 0; posIdx < data.Length; posIdx++)
        {
            plotModelInstances[posIdx] = GameObject.Instantiate(plotModel, new Vector3(data[posIdx].x,0f,data[posIdx].y), Quaternion.identity);
            plotModelInstances[posIdx].transform.localScale = new Vector3(1f, data[posIdx].z/1200, 1f);

            plotModelInstances[posIdx].GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(data[posIdx].z/1200, StaticValues.jet);
            
        }
    }

    public void ColorPlot(Color color)
    {
        foreach(GameObject modelInstance in plotModelInstances)
        {
            modelInstance.GetComponent<MeshRenderer>().material.color = color;
        }
    }

    public void ColorPlotRandom()
    {
        foreach(GameObject modelInstance in plotModelInstances)
        {
            float value = Random.Range(0f,1f);
            modelInstance.GetComponent<MeshRenderer>().material.color = MiscUtils.GetColor(value, StaticValues.jet);
        }
    }
}