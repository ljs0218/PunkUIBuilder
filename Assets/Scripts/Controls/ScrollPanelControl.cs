using Game.Scripts.UI;
using UnityEngine.UI;
using UnityEngine;
using Game.Scripts;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class ScrollPanelControl : Control
    {
        public Scripts.Graphics.Color color { get; set; }
        public string contentHash { get; set; }
        public bool horizontal { get; set; }
        public bool vertical { get; set; }
        public float scrollSensitivity { get; set; }
        public int movementType { get; set; }

#if UNITY_EDITOR
        private ScrollPanelControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyScrollRect();
            };
        }

        private void ApplyScrollRect()
        {
            if (this == null) { return; }

            ScrollRect scrollRect = GetComponent<ScrollRect>();
            if (scrollRect != null)
            {
                horizontal = scrollRect.horizontal;
                vertical = scrollRect.vertical;
                scrollSensitivity = scrollRect.scrollSensitivity;
                movementType = (int)scrollRect.movementType;
                color = Utility.ConvertToColor(scrollRect.GetComponent<Image>().color);
                contentHash = scrollRect.content.GetComponent<BaseControl>().hash;
            }
        }
#endif
    }
}