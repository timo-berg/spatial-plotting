using UnityEngine;

public struct ColorMap
{
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

	public Color[] colors;
	public string name;
}