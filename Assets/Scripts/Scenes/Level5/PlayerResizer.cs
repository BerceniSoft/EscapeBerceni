using UnityEngine;

namespace Scenes.Level5
{
    public class PlayerResizer : MonoBehaviour
    {
        private Transform _transform;
        private Vector3 _initialScale;
        
        [SerializeField]
        private float scalingFactor = 0.5f;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _initialScale = _transform.localScale;
        }

        private void FixedUpdate()
        {
            _transform.localScale = _initialScale + Vector3.one * (scalingFactor * -_transform.position.y);
        }
    }
}