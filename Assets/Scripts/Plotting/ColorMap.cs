using UnityEngine;

/// <summary>
/// Struct in which a map with 256 color is stored along with a name.
/// </summary>
public struct ColorMap
{
	public Color[] colors;
	public string name;

	public ColorMap(float[,] colorValues, string name)
	{
		Color[] colors = new Color[256];
		for (int idx = 0; idx < 256; idx++)
		{
			colors[idx] = new Color(colorValues[idx, 0], colorValues[idx, 1], colorValues[idx, 2]);
		}
		this.colors = colors;
		this.name = name;
	}
}