using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class LetterInventoryController : MonoBehaviour
    {
        public LetterScriptableObject[] letters;
        public Image[] imageRenderers;

        // Update is called once per frame
        void Update()
        {   
            for (int i = 0; i < Math.Min(letters.Length, imageRenderers.Length); i++)
            {
                if (letters[i].has)
                {
                    imageRenderers[i].sprite = letters[i].icon;
                    imageRenderers[i].enabled = true;
                }
            }
        }

        public void GiveLetter(int letterIndex)
        {
            letters[letterIndex].has = true;
            // imageRenderers[letterIndex].sprite = letters[letterIndex].icon;
            // imageRenderers[letterIndex].enabled = true;
        }
        
        public void RemoveLetter(int letterIndex)
        {
            letters[letterIndex].has = false;
        }

    }
}