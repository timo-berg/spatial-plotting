using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    Vector3[] data = new Vector3[9];
    public GameObject model;


    void Start()
    {
        Debug.Log(data.Length);
        data[0] = new Vector3 (0f, 0f, 0f);
        data[1] = new Vector3 (1f, 0f, 0f);
        data[2] = new Vector3 (2f, 0f, 0f);
        data[3] = new Vector3 (0f, 0f, 1f);
        data[4] = new Vector3 (1f, 0f, 1f);
        data[5] = new Vector3 (2f, 0f, 1f);
        data[6] = new Vector3 (0f, 0f, 2f);
        data[7] = new Vector3 (1f, 0f, 2f);
        data[8] = new Vector3 (2f, 0f, 2f);

        PlotManager.Instance.CreatePlot(data, model);
        BarPlot myPlot = PlotManager.Instance.barPlots[0];
        myPlot.DrawPlot();
        myPlot.ColorPlot(new Color(1, 0, 0));
    }
}
