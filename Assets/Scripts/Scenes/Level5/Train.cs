using Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Level5
{
    public class Train : Interactable.AbstractInteractableHandler
    {
        [SerializeField]
        private LetterInventoryController letterInventoryController;
        
        protected override void OnInteract()
        {
            letterInventoryController.GiveLetter(4);
            SceneManager.LoadScene("Metrou1");
        }
    }
}