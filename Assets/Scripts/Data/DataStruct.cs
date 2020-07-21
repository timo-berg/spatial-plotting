using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TwoCoords
{
    public float x { get; }
    public float y { get; }
       
    public TwoCoords(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

public struct ThreeCoords
{
    public float x { get; }
    public float y { get; }
    public float z { get; }
    public ThreeCoords(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public struct BarDataPoint
{
    public TwoCoords coords { get; }
    public float value { get; }
    public BarDataPoint(TwoCoords coords, float value)
    {
        this.coords = coords;
        this.value = value;
    }
}

public struct ScatterDataPoint
{
    public ThreeCoords coords { get; }
    public float value { get; }
    public ScatterDataPoint(ThreeCoords coords, float value)
	{
        this.coords = coords;
        this.value = value;
	}
}

public struct IntTuple
{
    public int x;
    public int y;
    public IntTuple(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}