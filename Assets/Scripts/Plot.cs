using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot
{
    protected GameObject plotModel;
    protected Vector3[] data; 
    protected Vector3 CenterPosition;
    protected GameObject[] plotModelInstances;
    public Plot()
    {
        CenterPosition = new Vector3(0f, 0f, 0f);
        data = new Vector3[1];
        data[0] = new Vector3(0f, 0f, 0f);
        Debug.Log("Plot instantiated with default data.");
    }

    public Plot(Vector3[] newData, GameObject newModel)
    {
        data = newData;
        plotModel = newModel;
        Debug.Log("Plot instantiated with custom data and model.");
    }
}
