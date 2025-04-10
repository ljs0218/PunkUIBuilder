using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;
using System.IO;
using Game.Scripts;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class TextControl : Control
    {
        public bool bestFit { get; set; }
        public Scripts.Graphics.Color color { get; set; }
        public bool horizontalOverflow { get; set; }
        public float lineSpacing { get; set; }
        public bool raycastTarget { get; set; }
        public string text { get; set; }
        public int textAlign { get; set; }
        public int textSize { get; set; }
        public bool verticalOverflow { get; set; }

#if UNITY_EDITOR
        private TextControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyText();
            };
        }

        private void ApplyText()
        {
            if (this == null) { return; }
            
            Text text = GetComponent<Text>();
            if (text != null)
            {
                bestFit = text.resizeTextForBestFit;
                color = Utility.ConvertToColor(text.color);
                horizontalOverflow = text.horizontalOverflow == HorizontalWrapMode.Overflow;
                lineSpacing = text.lineSpacing;
                raycastTarget = text.raycastTarget;
                textAlign = (int)text.alignment;
                textSize = text.fontSize;
                verticalOverflow = text.verticalOverflow == VerticalWrapMode.Overflow;
                this.text = text.text;
            }
        }
#endif
    }
}