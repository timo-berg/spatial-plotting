using TMPro;
using UnityEngine;

/// <summary>
/// Data Inspector Panel content controller.
/// </summary>
public class DataInspector : MonoBehaviour
{
	public Camera desktopCamera;
	public Camera vrCamera;
	private Camera playerCamera;

	public TextMeshProUGUI messageText;
	public GameObject dataInspectorCanvas;

	float targetShowDuration;
	float showingTime;
	bool isShowingText;

	void Update()
	{
		LookAtPlayer();
	}

	public void HideMessage()
	{
		dataInspectorCanvas.SetActive(false);
		messageText.text = "";
		isShowingText = false;
	}

	/// <summary>
	/// Print text to the panel
	/// </summary>
	public void ShowText(string text)
	{
		isShowingText = true;

		dataInspectorCanvas.SetActive(true);
		messageText.text = text;
	}

	/// <summary>
	/// Makes the panel always face the player
	/// TODO: Remove roll in VR
	/// </summary>
	void LookAtPlayer()
	{
		if (PlayerManager.Instance.isVR)
		{
			playerCamera = vrCamera;
		} else
		{
			playerCamera = desktopCamera;
		}

		Vector3 v = playerCamera.transform.position - transform.position;
		v.x = v.z = 0.0f;
		transform.LookAt(playerCamera.transform.position);
		transform.rotation = (playerCamera.transform.rotation);
	}
}
