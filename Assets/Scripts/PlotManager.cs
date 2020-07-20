using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : Singleton<PlotManager>
{
    public List<BarPlot> barPlots = new List<BarPlot>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlot(Vector3[] data, GameObject model)
    {
        BarPlot myBarPlot = new BarPlot(data, model);
        barPlots.Add(myBarPlot);
    }
}
