/// <summary>
/// Collection of data structures used throughout the library
/// </summary>


/// <summary>
/// Generic struct with two fields of the same type
/// </summary> 
public struct TwoTuple<T>
{
	public T x;
	public T y;
	public TwoTuple(T x, T y)
	{
		this.x = x;
		this.y = y;
	}

	public override string ToString()
	{
		return "(" + x + ", " + y + ")";
	}
}

/// <summary>
/// Generic struct with three fields of the same type
/// </summary>
public struct ThreeTuple<T>
{
	public T X { get; }
	public T Y { get; }
	public T Z { get; }
	public ThreeTuple(T x, T y, T z)
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
	}

	public override string ToString()
	{
		return "(" + X + ", " + Y + ", " + Z + ")";
	}
}

// DataPoint structures with properties according to the plot requirements

/// <summary>
/// Interface that has to be implemented by all data point structs
/// </summary>
public interface IDataPoint
{
	float Value { get; }

	string ToString();
}

/// <summary>
/// Data type used for BarPlots. Has 2D coordinates and a value field
/// </summary>
public struct BarDataPoint : IDataPoint
{
	public TwoTuple<float> Coords { get; }
	public float Value { get; }
	public BarDataPoint(TwoTuple<float> Coords, float Value)
	{
		this.Coords = Coords;
		this.Value = Value;
	}

	public override string ToString()
	{
		return "Coordinates: " + Coords + "; Value: " + Value;
	}
}

/// <summary>
/// Collection of data structures used throughout the library
/// </summary>
public struct ScatterDataPoint : IDataPoint
{
	public ThreeTuple<float> Coords { get; }
	public float Value { get; }
	public ScatterDataPoint(ThreeTuple<float> coords, float value)
	{
		this.Coords = coords;
		this.Value = value;
	}

	public override string ToString()
	{
		return "Coordinates: " + Coords + "; Value: " + Value;
	}
}

