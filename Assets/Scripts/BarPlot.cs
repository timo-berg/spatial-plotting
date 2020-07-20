using System.Collections;
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
            //GameObject instance = GameObject.Instantiate(plotModel, data[posIdx], Quaternion.identity);
            //instance.Transform.localScale = new Vector3(1f, Random.Range(0.0f, 5.0f), 1f);
            plotModelInstances[posIdx] = GameObject.Instantiate(plotModel, data[posIdx], Quaternion.identity);
            
            plotModelInstances[posIdx].transform.localScale = new Vector3(1f, Random.Range(0.0f, 5.0f), 1f);
            
        }
    }

    public void ColorPlot(Color color)
    {
        foreach(GameObject modelInstance in plotModelInstances)
        {
            modelInstance.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
