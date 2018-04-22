using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripto
{
	public sealed class GameClient : MonoBehaviour
	{
		private static GameClient _instance;

		public static LocationService Location { get; private set; }
		private void Awake() 
		{
			if(_instance != null)
			{
				Debug.LogError("Only one instance of GameClient allowed");
				return;
			}
			_instance = this;
			Location = gameObject.AddComponent<LocationService>();
			Location.Init();
		}

		private void Start()
		{
		}
	}
}