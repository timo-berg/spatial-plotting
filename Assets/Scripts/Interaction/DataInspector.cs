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
	public GameObject canvasChild;

	Vector3 vrOffset = new Vector3(0, 0, 1.2f);
	Vector3 desktopOffset = new Vector3(0, 0, 3f);

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ShowPanel();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			HidePanel();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			MovePanel();
		}
	}

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

	void ShowPanel()
	{
		canvasChild.SetActive(true);
		MovePanel();
	}

	void HidePanel()
	{
		canvasChild.SetActive(false);
	}

	void MovePanel()
	{
		Transform target = PlayerManager.Instance.GetPlayerTransform();
		transform.position = target.TransformPoint(PlayerManager.Instance.isVR ? vrOffset : desktopOffset);
		transform.rotation = target.rotation;
		transform.localEulerAngles += new Vector3(30, 0, 0);
	}
}
