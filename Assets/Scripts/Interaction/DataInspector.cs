using TMPro;
using UnityEngine;

/// <summary>
/// Data Inspector Panel content controller.
/// </summary>
public class DataInspector : MonoBehaviour
{
	public TextMeshProUGUI messageText;
	public GameObject dataInspectorCanvas;

	public void HideMessage()
	{
		dataInspectorCanvas.SetActive(false);
		messageText.text = "";
	}

	/// <summary>
	/// Print text to the panel
	/// </summary>
	public void ShowText(string text)
	{
		dataInspectorCanvas.SetActive(true);
		messageText.text = text;
	}

}
