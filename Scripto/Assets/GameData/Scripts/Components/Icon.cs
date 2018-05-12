using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripto
{
	public class Icon : MonoBehaviour
	{
		private RectTransform _canvasPosition;

		/// <summary>
		/// Initializes the Icon
		/// </summary>
		public void Init(GameObject iconGO)
		{
			_canvasPosition = (RectTransform) iconGO.transform;
		}

		/// <summary>
		/// Updates the position of the icon on the iconCanvas based on its world position
		/// </summary>
		public void UpdatePosition()
		{
			Vector3 screenPos = Camera.current.WorldToScreenPoint(transform.position);
			_canvasPosition.position = screenPos;
		}
	}
}
