using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripto
{
	public sealed class GameClient : MonoBehaviour
	{
		private static GameClient _instance;

		public static LocationService Location { get; private set; }
		public static IconService Icon { get; private set; }

		/// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static GameClient Instance
        {
            get { return _instance; }
        }

		/// <summary>
        /// Adds an Actor to the necessary Game Services.
        /// </summary>
        public static void AddActor(Actor actor)
		{
			Location.AddActor(actor);
			Icon.AddActor(actor);
		}

		private void Awake() 
		{
			if(_instance != null) 
			{
				Debug.LogError("Only one instance of GameClient allowed");
				return;
			}
			_instance = this;
			Location = gameObject.AddComponent<LocationService>();
			Icon = gameObject.AddComponent<IconService>();
			
			// Initialize all
			Location.Init();
			Icon.Init();
		}

		private void Start()
		{
			
		}
	}
}