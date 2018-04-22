using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionService
{
	private SpatialHashset<Actor> _actorPositions;

	public Actor GetNearestNeighbourActor(Vector2 position)
	{
		return _actorPositions.GetNearestNeighbour(position);
	}
}
