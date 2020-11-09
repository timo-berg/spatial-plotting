using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


// 1) Stand still for 30 seconds.
// 2) For at least one minute, keep going to the waypoint.
public class BaselineTask : MonoBehaviour
{
    #region fields

        const float kStandStillDuration = 30;
		const float kMinDistanceToNextWaypoint = 1.5f;

		bool hasShownPrompt;
		float startTimeOfFollowingWaypoints;
		float startTime;
		static List<List<Vector3>> trackerPositionTimeSeries;
		int trackerpositionIndex;
        static List<string> trackerPartNames;

    #endregion

    void Awake()
    {

        trackerPartNames = new List<string>();
        trackerPartNames[0] = "leftHand";
        trackerPartNames[1] = "rightHand";
        trackerPartNames[2] = "leftFoot";
        trackerPartNames[3] = "rightFoot";
        trackerPartNames[4] = "torso";

    }

    void AddWaypointSubTask()
	{

		// Choose the next waypoint that is not too close to the user
		List<Vector3> trackerpositions;
        
			trackerpositions            = trackerPositionTimeSeries[trackerpositionIndex];
			trackerpositionIndex        = (trackerpositionIndex + 1) % trackerPositionTimeSeries.Count;

	}



	static List<Vector3> LoadPositions(string filename)
	{
		List<Vector3> positions = new List<Vector3>();


		string[] lines = MiscUtils.GetLinesFromTextResource(filename);
		if ( lines.Length < 3 )
		{
			Debug.LogError("Transform file does not have three lines!");
			return positions;
		}

		string XcoordsLine = lines[0];
		string YcoordsLine = lines[1];
        string ZcoordsLine = lines[2];
        string[] xcoords = XcoordsLine.Split(',');
		string[] ycoords = YcoordsLine.Split(',');
        string[] zcoords = ZcoordsLine.Split(',');

        int index = 0;
		while ( index < xcoords.Length && index < ycoords.Length && index < zcoords.Length )
		{
			float x, y, z;

            // return when the end of the any of the lines is reached
			if ( false == float.TryParse(xcoords[index].Trim(), out x) )
				return positions;
			else if ( false == float.TryParse(ycoords[index].Trim(), out y) )
				return positions;
            else if (false == float.TryParse(zcoords[index].Trim(), out z))
                return positions;
            else
                positions.Add(new Vector3(x,y,z));

            index++;
		}
        
		return positions;
	}



}
