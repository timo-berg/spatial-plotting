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
	public void ShowData<T>(IDataPoint<T> dataPoint) where T : ITuple<float>
	{
		dataPointValue.text = dataPoint.Value.ToString();
		dataPointPosition.text = dataPoint.Coords.ToString();
	}

}
