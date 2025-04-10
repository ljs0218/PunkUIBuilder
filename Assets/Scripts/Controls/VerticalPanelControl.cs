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
    public class VerticalPanelControl : Control
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
        private VerticalPanelControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyLayerGroup();
            };
        }

        private void ApplyLayerGroup()
        {
            if (this == null) { return; }
            
            VerticalLayoutGroup verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            if (verticalLayoutGroup != null)
            {
                childAlign = (int)verticalLayoutGroup.childAlignment;
                childControlHeight = verticalLayoutGroup.childControlHeight;
                childControlWidth = verticalLayoutGroup.childControlWidth;
                childScaleWidth = verticalLayoutGroup.childScaleWidth;
                childScaleHeight = verticalLayoutGroup.childScaleHeight;
                childForceExpandWidth = verticalLayoutGroup.childForceExpandWidth;
                childForceExpandHeight = verticalLayoutGroup.childForceExpandHeight;
                spacing = verticalLayoutGroup.spacing;
                padding = new RectOff(
                    verticalLayoutGroup.padding.bottom,
                    verticalLayoutGroup.padding.left,
                    verticalLayoutGroup.padding.right,
                    verticalLayoutGroup.padding.top
                );
            }
        }
#endif
    }
}