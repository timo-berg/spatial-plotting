/// <summary>
/// Collection of data structures used throughout the library
/// </summary>

public interface ITuple<T>
{
	T X { get; }

	string ToString();
}
/// <summary>
/// Generic struct with two fields of the same type
/// </summary> 
public struct TwoTuple<T> : ITuple<T>
{
	public T X { get; }
	public T Y { get; }
	public TwoTuple(T x, T y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return "(" + X + ", " + Y + ")";
	}
}

/// <summary>
/// Generic struct with three fields of the same type
/// </summary>
public struct ThreeTuple<T> : ITuple<T>
{ 
	public T X { get; }
	public T Y { get; }
	public T Z { get; }
	public ThreeTuple(T x, T y, T z)
	{
		X = x;
		Y = y;
		Z = z;
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
public interface IDataPoint<TTuple>
{
	float Value { get; }
	TTuple Coords { get; }

	string ToString();
}

/// <summary>
/// Data type used for BarPlots. Has 2D coordinates and a value field
/// </summary>
public struct BarDataPoint : IDataPoint<TwoTuple<float>>
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
public struct ScatterDataPoint : IDataPoint<ThreeTuple<float>>
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

