using Enums;
using UnityEngine;

namespace Movement
{
    public class Followable : Walks
    {
        public SpriteOrientation GetSpriteOrientation()
        {
            return _currentSpriteOrientation;
        }
    }
}