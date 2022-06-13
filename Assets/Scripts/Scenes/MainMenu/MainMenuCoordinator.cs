using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.MainMenu
{
    public class MainMenuCoordinator : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Frateli");
        }
    }
}