using System.Text.RegularExpressions;
using System;
using UnityEngine;

/// <summary>
/// Class which handels all functions regarding data reading, parsing, and output
/// </summary>
public static class DataHandler
{
	/// <summary>
	/// Read in a .txt or .csv file and return its lines as a string array
	/// </summary>
	public static string[] GetLinesFromTextResource(string resourceName)
	{


		TextAsset textAsset = (TextAsset)Resources.Load(resourceName, typeof(TextAsset));
		string[] lines = Regex.Split(textAsset.text, "\n");
		Resources.UnloadAsset(textAsset);

		return lines;
	}

	/// <summary>
	/// Parser for BarPlot data. Takes in a string array from GetLinesFromTextResource,
	/// converts it to an array of BarDataPoints, and returns it
	/// </summary>
	public static BarDataPoint[] ParseBarPlotData(string[] data)
	{


		string[] xCoordsStrings = data[0].Split(',');
		string[] yCoordsStrings = data[1].Split(',');
		string[] valuesStrings = data[2].Split(',');

		BarDataPoint[] parsedData = new BarDataPoint[valuesStrings.Length];

		for (int idx = 0; idx < valuesStrings.Length; idx++)
		{
			parsedData[idx] = new BarDataPoint(new TwoTuple<float>((float)Math.Round(float.Parse(xCoordsStrings[idx]),2), (float)Math.Round(float.Parse(yCoordsStrings[idx]), 2)), float.Parse(valuesStrings[idx]));
		}

		return parsedData;
	}

	/// <summary>
	/// Parser for ScatterPlot data. Takes in a string array from GetLinesFromTextResource,
	/// converts it to an array of ScatterDataPoints, and returns it
	/// </summary>
	public static ScatterDataPoint[] ParseScatterPlotData(string[] data, int trial)
	{
		string[] xCoordsStrings = data[0].Split(',');
		string[] yCoordsStrings = data[1].Split(',');
		string[] zCoordsStrings = data[2].Split(',');

		ScatterDataPoint[] parsedData = new ScatterDataPoint[xCoordsStrings.Length];

		for (int idx = 0; idx < xCoordsStrings.Length; idx++)
		{
			parsedData[idx] = new ScatterDataPoint(new ThreeTuple<float>((float)Math.Round(float.Parse(xCoordsStrings[idx]), 2), (float)Math.Round(float.Parse(yCoordsStrings[idx]), 2), (float)Math.Round(float.Parse(zCoordsStrings[idx]), 2)), trial);
		}

		return parsedData;
	}
}
