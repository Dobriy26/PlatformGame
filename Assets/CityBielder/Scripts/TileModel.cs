using System;
using UnityEngine;


namespace CityBuilder.Scripts
{
    [Serializable]
    public class TileModel
    {
        public Vector2 indexes;
        public TileView TileView;
        public Vector3 rotate;
    }
}