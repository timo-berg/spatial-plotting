using TMPro;
using UnityEngine;

/// <summary>
/// Data Inspector Panel content controller.
/// </summary>
public class DataInspector : MonoBehaviour
{
	public TextMeshProUGUI dataPointPlot;
	public TextMeshProUGUI dataPointPosition;
	public TextMeshProUGUI dataPointValue;
	public GameObject dataInspectorCanvas;

	/// <summary>
	/// Print text to the panel
	/// </summary>
	public void ShowData(ScatterDataPoint dataPoint)
	{
		dataPointPlot.text = PlotManager.Instance.GetParentPlotDataPoint(dataPoint);
		dataPointValue.text = dataPoint.Value.ToString();
		dataPointPosition.text = dataPoint.Coords.ToString();
	}

	public void ShowData(BarDataPoint dataPoint)
	{
		dataPointPlot.text = PlotManager.Instance.GetParentPlotDataPoint(dataPoint);
		dataPointValue.text = dataPoint.Value.ToString();
		dataPointPosition.text = dataPoint.Coords.ToString();
	}

}
