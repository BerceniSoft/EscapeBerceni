using System;
using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class Teleporter : AbstractInteractableHandler
    {
        [SerializeField]
        private string nextSceneName;

        protected override void OnInteract()
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
