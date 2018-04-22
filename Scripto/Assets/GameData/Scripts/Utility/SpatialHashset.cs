using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripto
{
	public class SpatialHashset<T> where T : ISpatiallyKeyable
	{
		private Dictionary<Vector3, List<T>> _hashSetA;
		private Dictionary<Vector3, List<T>> _hashSetB;
		private List<List<T>> _listPool;
		private float _gridSize;

		#region public methods

		public SpatialHashset(float gridSize)
		{
			_hashSetA = new Dictionary<Vector3, List<T>>();
			_hashSetB = new Dictionary<Vector3, List<T>>();
			_listPool = new List<List<T>>();
			_gridSize = gridSize;
		}

		public T GetNearestNeighbour(T actor)
		{
			T neighbourA = GetNearestNeighbour(actor, _hashSetA, 0);
			T neighbourB = GetNearestNeighbour(actor, _hashSetB, _gridSize/2);
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
				return Closest(actor, neighbourA, neighbourB);
			}
		}

        public void Update(T actor)
        {
			KeySet keys = actor.GetSpatialKeySet();
			if(HashFunction(actor.GetPosition(), 0) != keys.key1 
				|| HashFunction(actor.GetPosition(), _gridSize/2) != keys.key2)
			{
				_hashSetA[keys.key1].Remove(actor);
				_hashSetB[keys.key2].Remove(actor);
            	Add(actor);
			}
        }

        public void Add(T actor)
        {
            Vector3 hashA = HashFunction(actor.GetPosition(), 0);
			if(_hashSetA.ContainsKey(hashA))
			{
				_hashSetA[hashA].Add(actor);
			}
			else
			{
				_hashSetA.Add(hashA, GetPooledList());
			}
            Vector3 hashB = HashFunction(actor.GetPosition(), _gridSize/2);
			if(_hashSetB.ContainsKey(hashB))
			{
				_hashSetB[hashB].Add(actor);
			}
			else
			{
				_hashSetB.Add(hashB, GetPooledList());
			}
			KeySet keySet = new KeySet();
			keySet.key1 = hashA;
			keySet.key2 = hashB;
			actor.SetSpatialKeySet(keySet);
        }

        private List<T> GetPooledList()
        {
            if(_listPool.Count > 0)
			{
				List<T> list = _listPool[_listPool.Count - 1];
				_listPool.RemoveAt(_listPool.Count - 1);
				return list;
			}
			else
			{
				return new List<T>();
			}
        }

        #endregion

        // Using Manhatten Distance.
		private float ManhattenDistance(Vector3 pos1, Vector3 pos2)
		{
			Vector3 pos = pos1 - pos2;
			return Math.Abs(pos.x) + Math.Abs(pos.y) + Math.Abs(pos.z);
		}
		
        // Making the assumption that all T params are different.
        private T Closest(T actor, T neighbourA, T neighbourB)
		{
			Vector3 pos = actor.GetPosition();
			float manhattenA = ManhattenDistance(pos, neighbourA.GetPosition());
			float manhattenB = ManhattenDistance(pos, neighbourB.GetPosition());
			if (manhattenA > manhattenB)
			{
				return neighbourB;
			}
			else
			{
				return neighbourA;
			}
		}

		private T GetNearestNeighbour(T actor, Dictionary<Vector3, List<T>> hashSet, float offset)
		{
			Vector3 hash = HashFunction(actor.GetPosition(), offset);
			List<T> neighbours = hashSet[hash];
			T result = default(T);
			float distance = float.MaxValue;
			Vector3 actorPosition = actor.GetPosition();
			foreach(T neighbour in neighbours)
			{
				float neighbourDistance = ManhattenDistance(actorPosition, neighbour.GetPosition());
				if(neighbourDistance < distance)
				{
					distance = neighbourDistance;
					result = neighbour;
				}
			}
			return result;
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
		public Vector3 key1;
		public Vector3 key2;
	}
}