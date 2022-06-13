using Movement;
using UnityEngine;

namespace Scenes.Level5
{
    public class BlackoutTrigger : MonoBehaviour
    {
        [SerializeField]
        private SubwayCoordinator coordinator;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                coordinator.StartBlackout();
                Destroy(gameObject);
            }
        }
    }
}
