using UnityEngine;

public static class MiscUtils
{
	/// <summary>
	/// Collection of functions that don't fit into an other class (yet).
	/// </summary>

	public static Color GetColor(float value, ColorMap colormap)
	{
		/// <summary>
		/// Returns the color at the corresponding position
		/// </summary> Takes in a value between 0 and 1 and a colormapt

		float value_clamp = Mathf.Clamp(value, 0f, 1f);
		int intIdx = (int)Mathf.Floor(value_clamp * 255);
		return colormap.colors[intIdx];
	}
}
