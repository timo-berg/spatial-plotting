using UnityEngine;
using System.Linq;

/// <summary>
/// Collection of various mathematical functions
/// </summary>
public static class MathFunctions
{
	/// <summary>
	/// Generates a random integer between min and max
	/// </summary>
	/// <param name="min">Smallest (inclusive) integer</param>
	/// <param name="max">Largest (inclusive) integer</param>
	public static int RandomInt(int min, int max)
	{
		float randFloat = Random.Range(min, max + 1);
		return Mathf.FloorToInt(randFloat);
	}

	/// <summary>
	/// Finds the maximum value of an array of a type that implements the IDataPoint interface
	/// </summary>
	public static float MaxBarValue<TDataPoint>(TDataPoint[] data) where TDataPoint : IDataPoint
	{
		float max = data.Max(x => x.Value);
		return max;
	}
}
