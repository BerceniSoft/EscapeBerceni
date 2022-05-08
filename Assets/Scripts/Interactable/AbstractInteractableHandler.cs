using System;
using Constants;
using UnityEngine;

namespace Interactable
{
    public abstract class AbstractInteractableHandler:MonoBehaviour

    {
       protected abstract void OnInteract();
       
       private void OnTriggerEnter2D(Collider2D other)
       {
           if (other.gameObject.layer == LayerMask.NameToLayer(Layers.MainCharacterLayer))
           {
               OnInteract();
           }
       }
    }
}