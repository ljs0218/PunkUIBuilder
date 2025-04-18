using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine;
using UnityEngine.UI;
using Game.Scripts;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectMask2D))]
    public class PanelControl : Control
    {
        public Scripts.Graphics.Color color { get; set; }
        public bool raycastTarget { get; set; }

#if UNITY_EDITOR
        private PanelControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyImage();
            };
        }

        private void ApplyImage()
        {
            if (this == null) { return; }
            
            var image = GetComponent<Image>();
            if (image != null)
            {
                color = Utility.ConvertToColor(image.color);
                raycastTarget = image.raycastTarget;
            }
        }
#endif
    }
}