using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Serializable]
    public enum CursorStyle
    {
        Default,
        Pointer,
    }

    [Serializable]
    private class CursorConfig
    {
        public CursorStyle style;
        public Texture2D texture;
    }

    [SerializeField]
    private List<CursorConfig> cursorConfigs = new();

    private readonly Dictionary<CursorStyle, Texture2D> _cursorTextures = new();
    private CursorStyle _previousStyle = CursorStyle.Default;
    private CursorStyle _currentStyle = CursorStyle.Default;

    public static CursorManager Instance { get; private set; }

    public void Awake()
    {
        foreach (var config in cursorConfigs)
        {
            _cursorTextures[config.style] = config.texture;
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        SetStyle(CursorStyle.Default);
    }

    public void SetStyle(CursorStyle style)
    {
        _previousStyle = _currentStyle;
        _currentStyle = style;
        Cursor.SetCursor(_cursorTextures[style], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void RestorePreviousStyle()
    {
        SetStyle(_previousStyle);
    }
}
