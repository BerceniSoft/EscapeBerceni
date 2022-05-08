using System;
using Constants;
using Movement;
using UnityEngine;

namespace Interactable
{
    public abstract class AbstractInteractableHandler:MonoBehaviour

    {
        // True if the collision should start the interaction
        private bool _interactOnCollision = false;
        private Camera _mainCamera;
       protected abstract void OnInteract();

       public MainCharacterMovement mainCharacterMovement;

       protected void StopInteraction()
       {
           _interactOnCollision = false;
       }

       void Start()
       {
           _mainCamera = Camera.main;
       }
       

       private void OnMouseDown()
       {
           _interactOnCollision = true;
       }

       private void OnTriggerEnter2D(Collider2D other)
       {
           if (other.gameObject.layer == LayerMask.NameToLayer(Layers.MainCharacterLayer))
           {
               if(_interactOnCollision)
               {
                   OnInteract();
               }
           }
       }
    }
}