using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    Vector3[] data = new Vector3[9];
    public GameObject model;
    public ColorMap jet;

    void Start()
    {
        string file = "IMT_heatmap";
        string[] data2 = MiscUtils.GetLinesFromTextResource(file);
        Vector3[] data3 = MiscUtils.ParseBarPlotData(data2);
        Debug.Log(data3[0]);

        PlotManager.Instance.CreatePlot(data3, model);
        BarPlot myPlot = PlotManager.Instance.barPlots[0];
        myPlot.DrawPlot();
        //myPlot.ColorPlotRandom();
    }
}
