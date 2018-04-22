using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripto
{
	public class LocationService : MonoBehaviour
	{
		private const float GridSize = 2f;
		private SpatialHashset<Actor> _actorPositions;
		
		#region public methods

		public void Init()
		{
			_actorPositions = new SpatialHashset<Actor>(GridSize);
		}

		public Actor GetNearestNeighbourActor(Actor actor)
		{
			return _actorPositions.GetNearestNeighbour(actor);
		}

        public void AddActor(Actor actor)
        {
            _actorPositions.Add(actor);
        }

        public void UpdateActor(Actor actor)
        {
            _actorPositions.Update(actor);
        }

        #endregion
    }
}
