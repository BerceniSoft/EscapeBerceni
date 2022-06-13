using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.Level5
{
    public class ElectricPanelMini : Interactable.AbstractInteractableHandler
    {
        [SerializeField]
        private ElectricPanel electricPanel;
        
        protected override void OnInteract()
        {
            electricPanel.gameObject.SetActive(true);
            mainCharacterMovement.PauseMovement();
        }
    }
}