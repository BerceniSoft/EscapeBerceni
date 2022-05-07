using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Movement
{
    public class Follow : MonoBehaviour
    {
        private Rigidbody2D _self;
        private SpriteOrientation _currentSpriteOrientation;
        private SpriteRenderer[] _spriteRenderers;

        public Rigidbody2D target;
        public SpriteOrientation initialSpriteOrientation;
  

        // Start is called before the first frame update
        void Start()
        {
            _self = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            _self.velocity = target.velocity;
        }
    }
}
