using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine;
using UnityEngine.UI;
using Game.Scripts;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class HorizontalPanelControl : Control
    {
        public int childAlign { get; set; }
        public bool childControlHeight { get; set; }
        public bool childControlWidth { get; set; }
        public bool childScaleWidth { get; set; }
        public bool childScaleHeight { get; set; }
        public bool childForceExpandWidth { get; set; }
        public bool childForceExpandHeight { get; set; }

        public float spacing { get; set; }
        public RectOff padding { get; set; }

#if UNITY_EDITOR
        private HorizontalPanelControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyLayerGroup();
            };
        }

        private void ApplyLayerGroup()
        {
            if (this == null) { return; }
            
            HorizontalLayoutGroup horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
            if (horizontalLayoutGroup != null)
            {
                childAlign = (int)horizontalLayoutGroup.childAlignment;
                childControlHeight = horizontalLayoutGroup.childControlHeight;
                childControlWidth = horizontalLayoutGroup.childControlWidth;
                childScaleWidth = horizontalLayoutGroup.childScaleWidth;
                childScaleHeight = horizontalLayoutGroup.childScaleHeight;
                childForceExpandWidth = horizontalLayoutGroup.childForceExpandWidth;
                childForceExpandHeight = horizontalLayoutGroup.childForceExpandHeight;
                spacing = horizontalLayoutGroup.spacing;
                padding = new RectOff(
                    horizontalLayoutGroup.padding.bottom,
                    horizontalLayoutGroup.padding.left,
                    horizontalLayoutGroup.padding.right,
                    horizontalLayoutGroup.padding.top
                );
            }
        }
#endif
    }
}