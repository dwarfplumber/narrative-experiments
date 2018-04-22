using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialHashset<T> where T : ISpatiallyKeyable
{
    private Dictionary<Vector3, List<T>> _hashSetA;
	private Dictionary<Vector3, List<T>> _hashSetB;
	private float _gridSize;

	public SpatialHashset(float gridSize)
	{
		_hashSetA = new Dictionary<Vector3, List<T>>();
		_hashSetB = new Dictionary<Vector3, List<T>>();
		_gridSize = gridSize;
	}

    public T GetNearestNeighbour(Vector3 position)
    {
		T neighbourA = GetNearestNeighbour(position, _hashSetA);
		T neighbourB = GetNearestNeighbour(position, _hashSetB);
		if(neighbourA.Equals(neighbourB))
		{
			return neighbourA;
		}
		else if(neighbourA == null)
		{
			return neighbourB;
		}
		else if(neighbourB == null)
		{
			return neighbourA;
		}
		else
		{
			return Closest(position, neighbourA, neighbourB);
		}
    }

    private T Closest(Vector3 position, T neighbourA, T neighbourB)
    {
        return neighbourA; // TODO
    }

    private T GetNearestNeighbour(Vector3 position, Dictionary<Vector3, List<T>> hashSet)
    {
        return hashSet[Vector3.zero][0]; // TODO
    }

    private Vector3 HashFunction(Vector3 position, float offset)
	{
		return new Vector3((int)(position.x/_gridSize + offset), (int)(position.y/_gridSize + offset), (int)(position.z/_gridSize + offset));
	}
}

public interface ISpatiallyKeyable
{
	KeySet GetSpatialKeySet();
	void SetSpatialKeySet(KeySet keys);
	Vector3 GetPosition();
}

public struct KeySet
{
	Vector3 key1;
	Vector3 key2;
}