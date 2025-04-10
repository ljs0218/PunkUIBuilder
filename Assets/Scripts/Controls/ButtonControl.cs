using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using Game.Scripts;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class ButtonControl : Control
    {
        public Scripts.Graphics.Color color { get; set; }
        public int fontStyle { get; set; }
        public float lineSpacing { get; set; }
        public string text { get; set; }
        public int textAlign { get; set; }
        public int textSize { get; set; }
        public string image { get; set; }
        public Scripts.Graphics.Color textColor { get; set; }
        public bool horizontalOverflow { get; set; }
        public bool verticalOverflow { get; set; }

#if UNITY_EDITOR
        private ButtonControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyButton();
            };
        }

        private void ApplyButton()
        {
            if (this == null) { return; }

            Button button = GetComponent<Button>();
            if (button != null)
            {
                Image image = GetComponent<Image>();
                if (image == null)
                {
                    return;
                }

                Text text = GetComponentInChildren<Text>();
                if (text == null)
                {
                    return;
                }

                color = Utility.ConvertToColor(image.color);
                fontStyle = (int)text.fontStyle;
                lineSpacing = text.lineSpacing;
                textAlign = (int)text.alignment;
                textSize = text.fontSize;
                this.text = text.text;
                this.image = Utility.GetSpritePath(image.sprite);
                textColor = Utility.ConvertToColor(text.color);
                horizontalOverflow = text.horizontalOverflow == HorizontalWrapMode.Overflow;
                verticalOverflow = text.verticalOverflow == VerticalWrapMode.Overflow;
            }
        }
#endif
    }
}