using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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

    public static string[] GetLinesFromTextResource(string resourceName)
    {

        /// <summary>
        /// Load and read lines from text resource
        /// </summary> Takes in a string containing the nameof the text file

        TextAsset textAsset = (TextAsset)Resources.Load(resourceName, typeof(TextAsset));
        string[] lines = Regex.Split(textAsset.text, "\n");
        Resources.UnloadAsset(textAsset);
        
        return lines;
    }

    public static List<string> IndexList(List<string> list, List<int> indices)
    {
        /// <summary>
        /// Select elements in the list by indices
        /// Takes in a list of strings from which items should be selected and a list of indices
        /// Returns a new list of strings
        /// <summary>

        List<string> indexedList = new List<string>();
        for (int i = 0; i < list.Count; i++)
            if (indices.Contains(i))
                indexedList.Add(list[i]);

        return indexedList;
    }



}
