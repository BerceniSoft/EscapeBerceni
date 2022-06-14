using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class DuckInventoryController : MonoBehaviour
    {
        public DuckScriptableObject duck;
        public Image duckImage;

        // Update is called once per frame
        void Update()
        {
            if(duck.has)
            {
                duckImage.sprite = duck.icon;
                duckImage.enabled = true;
            }
        }

        public void GiveDuck()
        {
            duck.has = true;
        }

        public void RemoveDuck()
        {
            duck.has = false;
        }
    }
}