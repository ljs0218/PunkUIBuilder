using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Game.Scripts;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class ImageControl : Control
    {
        public Scripts.Graphics.Color color { get; set; }
        public float fillAmount { get; set; }
        public bool fillClockwise { get; set; }
        public int fillMethod { get; set; }
        public string image { get; set; }
        public int imageType { get; set; }
        public bool raycastTarget { get; set; }
        public RectOff sliceBorder { get; set; }

#if UNITY_EDITOR
        private ImageControl()
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
                fillAmount = image.fillAmount;
                fillClockwise = image.fillClockwise;
                fillMethod = (int)image.type;
                imageType = (int)image.type;
                raycastTarget = image.raycastTarget;
                this.image = Utility.GetSpritePath(image.sprite);
                masked = false;

                if (image.type == Image.Type.Sliced)
                {
                    // TODO: ����
                    //sliceBorder = new RectOff(image.sprite.border.x, image.sprite.border.y, image.sprite.border.z, image.sprite.border.w);
                }
                else
                {
                    sliceBorder = new RectOff(0, 0, 0, 0);
                }
            }
        }
#endif
    }
}