using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform Target;

        private void LateUpdate()
        {
            transform.position = Target.position;
        }
    } 
}


