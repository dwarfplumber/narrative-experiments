using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClient : MonoBehaviour {

	private PositionService _positionService;
	void Awake () 
	{
		_positionService = new PositionService();
	}
}
