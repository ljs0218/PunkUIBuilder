using Game.Scripts.Graphics;
using Game.Scripts.UI;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

#endif
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class BaseControl : MonoBehaviour
    {
        [SerializeField]
        public string _hash = string.Empty;

        public string hash { get; set; }
        public uint anchor { get; set; }
        public string controlName { get; set; }
        public int opacity { get; set; } = 255;
        public float pivotX { get; set; }
        public float pivotY { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float rotation { get; set; }
        public bool visible { get; set; } = true;

#if UNITY_EDITOR
        public BaseControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyRectTransform();
            };
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(_hash))
            {
                _hash = System.Guid.NewGuid().ToString("N");
                EditorUtility.SetDirty(this); // ���� ���� ����
            }

            hash = _hash;
        }

        private void ApplyRectTransform()
        {
            if (this == null)
            {
                return;
            }

            var rectTransform = GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                Vector2 anchoredPos = rectTransform.anchoredPosition;
                Vector2 size = rectTransform.sizeDelta;
                Vector2 pivot = rectTransform.pivot;
                Vector3 rotationEuler = rectTransform.localEulerAngles;

                anchor = Utility.GetAnchorValue(rectTransform);
                controlName = gameObject.name;
                pivotX = pivot.x;
                pivotY = pivot.y;
                x = anchoredPos.x;
                y = anchoredPos.y;
                width = size.x;
                height = size.y;
                rotation = rotationEuler.z;
                visible = gameObject.activeSelf;

                pivotX = pivot.x;
                pivotY = 1f - pivot.y;

                x = anchoredPos.x;
                y = -anchoredPos.y;

                hash = _hash;

                Image image = GetComponent<Image>();
                if (image != null)
                {
                    opacity = (int)(image.color.a * 255);
                }

                Text text = GetComponent<Text>();
                if (text != null)
                {
                    opacity = (int)(text.color.a * 255);
                }
            }
        }
#endif
    }

    [ExecuteAlways]
    [System.Serializable]
    public class Control : BaseControl
    {
        public bool masked { get; set; }
        public bool showOnTop { get; set; } = false;
        public bool _showOnTop;

#if UNITY_EDITOR
        public Control()
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
                masked = image.maskable;
            }

            showOnTop = _showOnTop;
        }
#endif
    }
}