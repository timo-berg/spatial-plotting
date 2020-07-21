using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class MiscUtils
{
    public static Color GetColor(float value, ColorMap colormap)
    {
        float value_clamp = Mathf.Clamp(value, 0f, 1f);
        int intIdx = (int)Mathf.Floor(value_clamp*255);
        return colormap.colors[intIdx];
    }
}
