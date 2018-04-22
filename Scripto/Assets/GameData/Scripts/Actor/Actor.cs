using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripto
{
    public class Actor : MonoBehaviour, ISpatiallyKeyable {

        private KeySet _spatialKeySet;

        #region public methods

        public KeySet GetSpatialKeySet()
        {
            return _spatialKeySet;
        }

        public void SetSpatialKeySet(KeySet keys)
        {
            _spatialKeySet = keys;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        #endregion

        private void Start () 
        {
            GameClient.Location.AddActor(this);
        }
        
        private void Update () 
        {
            GameClient.Location.UpdateActor(this);
        }
    }
}
