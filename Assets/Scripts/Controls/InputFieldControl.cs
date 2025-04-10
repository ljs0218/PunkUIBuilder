using UnityEngine.UI;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class InputFieldControl : Control
    {
        public int characterLimit { get; set; }
        public Scripts.Graphics.Color color { get; set; }
        public int contentType { get; set; }
        public float cursorRate { get; set; }
        public string imagePath { get; set; }
        public int lineType { get; set; }
        public string placeholder { get; set; }
        public string text { get; set; }
        public int textAlign { get; set; }
        public int textSize { get; set; }

#if UNITY_EDITOR
        private InputFieldControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyInputField();
            };
        }

        private void ApplyInputField()
        {
            if (this == null) { return; }
            
            InputField text = GetComponent<InputField>();
            if (text != null)
            {
                characterLimit = text.characterLimit;
                color = Utility.ConvertToColor(text.textComponent.color);
                contentType = (int)text.contentType;
                cursorRate = text.caretBlinkRate;
                imagePath = text.image != null ? AssetDatabase.GetAssetPath(text.image) : string.Empty;
                lineType = (int)text.lineType;
                placeholder = text.placeholder != null ? text.placeholder.GetComponent<Text>().text : string.Empty;
                textAlign = (int)text.textComponent.alignment;
                textSize = text.textComponent.fontSize;
                this.text = text.text;
            }
        }
#endif
    }
}