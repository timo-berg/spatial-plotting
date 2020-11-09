using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LimbController : MonoBehaviour
    {
        public string trackerType; 
        public float moveSpeed = 1.0f;
        int currentPointIndex = 0;
        Vector3 destinationVector;
        Vector3 offsetVector; 
        IKAvatar ikavatar;
        bool isNullOrWhiteSpace;
        string[] lines; 
        string[] xcoords;
        string[] ycoords;
        string[] zcoords;
        string[] trialIndices;
        int rowTriadIndex;
        int trialIndex;     

    void Start()
        {
        ikavatar = GetComponentInParent<IKAvatar>(); 
        lines = ikavatar.lines;
        offsetVector = ikavatar.offsetCoords;
        trialIndex = ikavatar.trialIndex; 
        
        // tracker type now defines which rows to read in from the test file 
        switch(trackerType)
        {
        case "torso":
            rowTriadIndex = 0;
            break;
        case "leftHand":
            rowTriadIndex = 1;
            break;
        case "rightHand":
            rowTriadIndex = 2;
            break;
        case "leftFoot":
            rowTriadIndex = 3;
            break;
        case "rightFoot":
            rowTriadIndex = 4;
            break; 
        default:
            print("incorrect tracker definition.");
            break;
        }

        string XcoordsLine = lines[rowTriadIndex * 3 ];
        string YcoordsLine = lines[rowTriadIndex * 3 + 2];
        string ZcoordsLine = lines[rowTriadIndex * 3 + 1];
        string trialIndexLine = lines[15]; 
        
        trialIndices  = trialIndexLine.Split(',');

        var indices = new List<int>();
        for (int i = 0; i < trialIndices.Length; i++)
            if (trialIndices[i].Equals(trialIndex.ToString()))
                indices.Add(i);

        xcoords = XcoordsLine.Split(',');
        ycoords = YcoordsLine.Split(',');
        zcoords = ZcoordsLine.Split(',');

        List<string> xList = xcoords.OfType<string>().ToList();
        List<string> yList = ycoords.OfType<string>().ToList();
        List<string> zList = zcoords.OfType<string>().ToList();

        xList = MiscUtils.IndexList(xList, indices);
        yList = MiscUtils.IndexList(yList, indices);
        zList = MiscUtils.IndexList(zList, indices);

        xcoords = xList.ToArray();
        ycoords = yList.ToArray();
        zcoords = zList.ToArray();


    }

    void Update()
        {

        if (destinationVector == null || transform.localPosition == destinationVector)
        {
            currentPointIndex = currentPointIndex < xcoords.Length - 1 ? currentPointIndex + 3 : 1;


                
                destinationVector = new Vector3( float.Parse(xcoords[currentPointIndex]), float.Parse(ycoords[currentPointIndex]),  float.Parse(zcoords[currentPointIndex])) + offsetVector;


        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destinationVector, Time.deltaTime * moveSpeed);

        }

    }

}

