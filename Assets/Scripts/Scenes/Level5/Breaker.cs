using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Level5
{
    public class Breaker : MonoBehaviour
    {
        [SerializeField]
        private Sprite on;

        [SerializeField]
        private Sprite off;

        private Image _image;

        private bool _on = false;

        public bool On
        {
            get => _on;
            set
            {
                _image.sprite = value ? on : off;
                _on = value;
            }
        }

        public Button Button { get; private set; }

        public List<Breaker> connectedBreakers = new ();

        private void Awake()
        {
            _image = GetComponent<Image>();

            // Prevent this breaker from accidentally being connected to itself.
            connectedBreakers.RemoveAll(x => x == this);
            
            Button = GetComponent<Button>();
            Button.onClick.AddListener(() =>
            {
                Flip();
                connectedBreakers.ForEach(x => x.Flip());
            });
        }

        public void Flip() => On = !On;
    }
}