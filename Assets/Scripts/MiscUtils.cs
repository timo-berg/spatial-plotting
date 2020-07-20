using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class MiscUtils
{
    public static Color GetColor(float value, ColorMap colormap)
    {
        int intIdx = (int)Mathf.Floor(value*256);
        return colormap.colors[intIdx];
    }

    public static string[] GetLinesFromTextResource( string resourceName )
	{
		TextAsset textAsset = (TextAsset) Resources.Load(resourceName, typeof(TextAsset));
		//string[] lines = Regex.Split( textAsset.text, "\r\n|\r|\n" );
        string[] lines = Regex.Split(textAsset.text, "\n");
        Resources.UnloadAsset(textAsset);
		
		return lines;
	}

    public static Vector3[] ParseBarPlotData(string[] data)
    {
        string[] xCoordsStrings = data[0].Split(',');
        string[] yCoordsStrings = data[1].Split(',');
        string[] valuesStrings = data[2].Split(',');

        Vector3[] parsedData = new Vector3[valuesStrings.Length];

        for (int idx = 0; idx < valuesStrings.Length; idx++)
        {
            parsedData[idx] = new Vector3(float.Parse(xCoordsStrings[idx]), float.Parse(yCoordsStrings[idx]) , float.Parse(valuesStrings[idx]));
        }

        return parsedData;
    }    
}
