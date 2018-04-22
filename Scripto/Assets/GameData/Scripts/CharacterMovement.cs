using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	[SerializeField] private float _speed = 0.1f;
	void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
				Vector3 position = this.transform.position;
				position.x-= _speed;
				this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
				Vector3 position = this.transform.position;
				position.x+= _speed;
				this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
				Vector3 position = this.transform.position;
				position.y+= _speed;
				this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
				Vector3 position = this.transform.position;
				position.y-= _speed;
				this.transform.position = position;
		}
	}
}
