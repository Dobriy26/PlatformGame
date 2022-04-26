using UnityEngine;

namespace CityBuilder.Scripts.Core
{
    public static class Helper
    {
        public static bool RayCastOnComponent<T>(Vector3 origin, 
            Vector3 direction, out T target)
        {
            return RayCastOnComponent(new Ray(origin, direction), out target);
        }
        
        public static bool RayCastOnComponent<T>(Ray ray, out T target)
        {
            if (Physics.Raycast(ray, out var hit))
            {
                return hit.transform.TryGetComponent(out target);
            }

            target = default;
            return false;
        }
        
    }
}