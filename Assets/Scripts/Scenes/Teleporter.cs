using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private string nextSceneName;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
