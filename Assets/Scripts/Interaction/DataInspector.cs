using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataInspector : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public GameObject dataInspectorCanvas;

    float targetShowDuration;
    float showingTime;
    bool isShowingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideMessage()
    {
        dataInspectorCanvas.SetActive(false);
        messageText.text = "";
        isShowingText = false;
    }
    
    public void ShowText(string text)
    {
        isShowingText = true;

        dataInspectorCanvas.SetActive(true);
        messageText.text = text;
    }
}
