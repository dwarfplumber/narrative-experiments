using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, ISpatiallyKeyable {

	private KeySet _spatialKeySet;
    public KeySet GetSpatialKeySet()
    {
        return _spatialKeySet;
    }

    public void SetSpatialKeySet(KeySet keys)
    {
        _spatialKeySet = keys;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
