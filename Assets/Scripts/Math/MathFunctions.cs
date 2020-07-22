using UnityEngine;

public static class MathFunctions
{
	// Collection of various mathematical functions

	public static int RandomInt(int min, int max)
	{
		// Generates a random integer between (inclusive) min and (inclusive) max
		float randFloat = Random.Range(min, max + 1);
		return Mathf.FloorToInt(randFloat);
	}

	public static float MaxBarValue<TDataPoint>(TDataPoint[] data) where TDataPoint : IDataPoint
	{
		// Finds the maximum value of an BarData array
		float maxValue = data[0].Value;
		foreach (TDataPoint dataPoint in data)
		{
			maxValue = (maxValue < dataPoint.Value) ? dataPoint.Value : maxValue;
		}
		return maxValue;
	}
}
