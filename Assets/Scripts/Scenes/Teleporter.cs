using System;
using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class Teleporter : AbstractInteractableHandler
    {
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider2D;
        public bool isActive = true;
        [SerializeField]
        private string nextSceneName;

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider2D = GetComponent<BoxCollider2D>();

            if (!isActive)
            {
                _spriteRenderer.enabled = false;
                _collider2D.enabled = false;
                _rigidbody.isKinematic = true;
            }
        }

        public void ToggleActvie()
        {
            isActive = !isActive;
            _spriteRenderer.enabled = isActive;
            _collider2D.enabled = isActive;
            _rigidbody.isKinematic = !isActive;
        }

        protected override void OnInteract()
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
