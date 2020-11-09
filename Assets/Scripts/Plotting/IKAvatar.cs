using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAvatar: MonoBehaviour {

    public string playerName;
    public int trialIndex;
    public Vector3 offsetCoords; 
    public Color modelColor;
    public string[] lines;
    string fileName;


    void Awake()
    {

        fileName = playerName;
        lines = MiscUtils.GetLinesFromTextResource(fileName);

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = modelColor;

        }

    }

}
