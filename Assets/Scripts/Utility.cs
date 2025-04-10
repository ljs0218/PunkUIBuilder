using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Game.Scripts
{
    public enum Anchor
    {
        TopLeft = 0,
        TopCenter = 1,
        TopRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        BottomLeft = 6,
        BottomCenter = 7,
        BottomRight = 8,
        TopStretch = 9,
        MiddleStretch = 10,
        BottomStretch = 11,
        LeftStretch = 12,
        CenterStretch = 13,
        RightStretch = 14,
        Stretch = 15
    }

    public class Utility
    {
        public static Scripts.Graphics.Color ConvertToColor(UnityEngine.Color color)
        {
            return new Scripts.Graphics.Color((int)(color.r * 255), (int)(color.g * 255), (int)(color.b * 255), (int)(color.a * 255));
        }

        public static uint GetAnchorValue(RectTransform rectTransform)
        {
            Vector2 min = rectTransform.anchorMin;
            Vector2 max = rectTransform.anchorMax;

            if (min == new Vector2(0, 1) && max == new Vector2(0, 1)) return 0;  // TopLeft
            if (min == new Vector2(0.5f, 1) && max == new Vector2(0.5f, 1)) return 1;  // TopCenter
            if (min == new Vector2(1, 1) && max == new Vector2(1, 1)) return 2;  // TopRight

            if (min == new Vector2(0, 0.5f) && max == new Vector2(0, 0.5f)) return 3;  // MiddleLeft
            if (min == new Vector2(0.5f, 0.5f) && max == new Vector2(0.5f, 0.5f)) return 4;  // MiddleCenter
            if (min == new Vector2(1, 0.5f) && max == new Vector2(1, 0.5f)) return 5;  // MiddleRight

            if (min == new Vector2(0, 0) && max == new Vector2(0, 0)) return 6;  // BottomLeft
            if (min == new Vector2(0.5f, 0) && max == new Vector2(0.5f, 0)) return 7;  // BottomCenter
            if (min == new Vector2(1, 0) && max == new Vector2(1, 0)) return 8;  // BottomRight

            if (min == new Vector2(0, 1) && max == new Vector2(1, 1)) return 9;  // TopStretch
            if (min == new Vector2(0, 0.5f) && max == new Vector2(1, 0.5f)) return 10; // MiddleStretch
            if (min == new Vector2(0, 0) && max == new Vector2(1, 0)) return 11; // BottomStretch

            if (min == new Vector2(0, 0) && max == new Vector2(0, 1)) return 12; // LeftStretch
            if (min == new Vector2(0.5f, 0) && max == new Vector2(0.5f, 1)) return 13; // CenterStretch
            if (min == new Vector2(1, 0) && max == new Vector2(1, 1)) return 14; // RightStretch

            if (min == new Vector2(0, 0) && max == new Vector2(1, 1)) return 15; // Stretch

            return 4; // ±âº»°ª: MiddleCenter
        }

        public static string GetSpritePath(Sprite sprite)
        {
            string path = string.Empty;
            if (sprite)
            {
                path = AssetDatabase.GetAssetPath(sprite);
                path = path.Replace("Assets/Resources/", string.Empty);
            }
            else
            {
                path = string.Empty;
            }
            return path;
        }
    }
}