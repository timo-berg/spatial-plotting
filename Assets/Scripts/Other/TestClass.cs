using UnityEngine;

public class TestClass : MonoBehaviour
{
	public GameObject cube;
	public GameObject disk;
	public ColorMap jet;

	void Start()
	{
		string barFile = "IMT_sub-009_trial-1_heatmap";
		string[] barDataString = DataHandler.GetLinesFromTextResource(barFile);
		BarDataPoint[] barData = DataHandler.ParseBarPlotData(barDataString);

		BarPlot myPlot = new BarPlot(barData, cube, 0.05f, barHeight: 1);
		myPlot.DrawPlot();

		string scatterFile = "IMT_sub-009_trial-1_scatter";
		string[] scatterDataString = DataHandler.GetLinesFromTextResource(scatterFile);
		ScatterDataPoint[] scatterData = DataHandler.ParseScatterPlotData(scatterDataString);

		ScatterPlot myPlot2 = new ScatterPlot(scatterData, disk, 0.1f, new Vector3(0f, 0f, 0.25f));
		myPlot2.DrawPlot();

	}
}
