using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class DataHandler
{
    public static string[] GetLinesFromTextResource( string resourceName )
	{
		TextAsset textAsset = (TextAsset) Resources.Load(resourceName, typeof(TextAsset));
        string[] lines = Regex.Split(textAsset.text, "\n");
        Resources.UnloadAsset(textAsset);
		
		return lines;
	}

    public static BarDataPoint[] ParseBarPlotData(string[] data)
    {
        string[] xCoordsStrings = data[0].Split(',');
        string[] yCoordsStrings = data[1].Split(',');
        string[] valuesStrings = data[2].Split(',');

        BarDataPoint[] parsedData = new BarDataPoint[valuesStrings.Length];

        for (int idx = 0; idx < valuesStrings.Length; idx++)
        {
            parsedData[idx] = new BarDataPoint(new TwoCoords(float.Parse(xCoordsStrings[idx]), float.Parse(yCoordsStrings[idx])) , float.Parse(valuesStrings[idx]));
        }

        return parsedData;
    }

    public static ScatterDataPoint[] ParseScatterPlotData(string[] data)
	{
        string[] xCoordsStrings = data[0].Split(',');
        string[] yCoordsStrings = data[1].Split(',');
        string[] zCoordsStrings = data[2].Split(',');

        ScatterDataPoint[] parsedData = new ScatterDataPoint[xCoordsStrings.Length];

        for (int idx = 0; idx < xCoordsStrings.Length; idx++)
        {
            parsedData[idx] = new ScatterDataPoint(new ThreeCoords(float.Parse(xCoordsStrings[idx]), float.Parse(yCoordsStrings[idx]), float.Parse(zCoordsStrings[idx])), 1f);
        }

        return parsedData;
    }
}
