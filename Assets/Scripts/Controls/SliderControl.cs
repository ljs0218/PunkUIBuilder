using UnityEngine.UI;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class SliderControl : Control
    {
        public float backgroundTop { get; set; }
        public float backgroundBottom { get; set; }
        public string backgroundImage { get; set; }
        public int direction { get; set; }
        public string fillImage { get; set; }
        public bool handleActive { get; set; }
        public string handleImage { get; set; }
        public float handleWidth { get; set; }
        public float minAmount { get; set; }
        public float maxAmount { get; set; }
        public float value { get; set; }

#if UNITY_EDITOR
        private SliderControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplySlider();
            };
        }

        private void ApplySlider()
        {
            if (this == null) { return; }
            
            Slider text = GetComponent<Slider>();
            if (text != null)
            {
                backgroundTop = text.fillRect != null ? text.fillRect.GetComponent<RectTransform>().anchoredPosition.y : 0;
                backgroundBottom = text.fillRect != null ? text.fillRect.GetComponent<RectTransform>().anchoredPosition.y : 0;
                backgroundImage = text.fillRect != null ? AssetDatabase.GetAssetPath(text.fillRect.GetComponent<Image>().sprite) : string.Empty;
                direction = (int)text.direction;
                fillImage = text.fillRect != null ? AssetDatabase.GetAssetPath(text.fillRect.GetComponent<Image>().sprite) : string.Empty;
                handleActive = text.handleRect != null && text.handleRect.gameObject.activeSelf;
                handleImage = text.handleRect != null ? AssetDatabase.GetAssetPath(text.handleRect.GetComponent<Image>().sprite) : string.Empty;
                handleWidth = text.handleRect != null ? text.handleRect.sizeDelta.x : 0;
                minAmount = text.minValue;
                maxAmount = text.maxValue;
                value = text.value;
            }
        }
#endif
    }
}