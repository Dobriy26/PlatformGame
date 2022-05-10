using UnityEngine;

namespace CityBuilder.Scripts
{
    [RequireComponent(typeof(Renderer))]
    public class GoalView: MonoBehaviour
    {
        private Renderer _renderer;

        public Renderer Renderer
        {
            get
            {
                if (_renderer == null)
                {
                    _renderer = GetComponent<Renderer>();
                }

                return _renderer;
            }
            
        }
    }
}