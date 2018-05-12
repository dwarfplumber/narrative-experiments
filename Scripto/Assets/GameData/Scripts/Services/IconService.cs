using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripto
{
	public class IconService : MonoBehaviour 
	{
		private GameObject _canvasGameObject;
		private Canvas _iconCanvas;
		private List<Icon> _icons;

		/// <summary>
        /// Initializes the IconService
        /// </summary>
		public void Init()
		{
			_canvasGameObject = new GameObject("Icons");
			_canvasGameObject.transform.parent = GameClient.Instance.gameObject.transform;

			GameObject prefab = Resources.Load<GameObject>("Prefabs/IconCanvas");
            Assert.IsNotNull(prefab);
            GameObject go = GameObject.Instantiate<GameObject>(prefab, _canvasGameObject.transform);
            Assert.IsNotNull(go);

            go.name = "IconCanvas";

            _iconCanvas = go.GetComponent<Canvas>();
            Assert.IsNotNull(_iconCanvas);

			_icons = new List<Icon>();
		}

		/// <summary>
		/// Adds an Actor to the IconService for updating
		/// </summary>
		public void AddActor(Actor actor)
		{
			Icon icon = actor.gameObject.GetComponentInChildren<Icon>();
			if(icon == null)
			{
				Debug.LogError("Cannot find Icon on Actor.");
				return;
			}
			GameObject prefab = Resources.Load<GameObject>("Prefabs/ActorIcon");
			GameObject go = GameObject.Instantiate<GameObject>(prefab, _iconCanvas.transform);
			icon.Init(go);
			_icons.Add(icon);
		}

		/// <summary>
		/// Updates positions of all the Icons
		/// </summary>
		private void LateUpdate()
		{
			foreach(Icon icon in _icons)
			{
				icon.UpdatePosition();
			}
		}
	}
}
