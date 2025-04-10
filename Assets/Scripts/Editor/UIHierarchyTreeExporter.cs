using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [InitializeOnLoad]
    public class UIHierarchyTreeExporter
    {
        static UIHierarchyTreeExporter()
        {
            EditorSceneManager.sceneSaved += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged(UnityEngine.SceneManagement.Scene scene)
        {
            EditorApplication.delayCall += () => {
                // 프리팹 창에서 변경시 리턴
                if (PrefabStageUtility.GetCurrentPrefabStage() != null)
                    return;

                var allCanvases = Object.FindObjectsOfType<Canvas>();

                foreach (var canvas in allCanvases)
                {
                    // 원하는 조건이 있다면 추가 (예: active 상태, 특정 이름 등)
                    if (canvas.gameObject.scene.isLoaded)
                    {
                        Export(canvas);
                    }
                }
            };
        }


        [System.Serializable]
        public class UIElementNode
        {
            public string type;
            public Dictionary<string, object> properties = new Dictionary<string, object>();
            public List<UIElementNode> children = new List<UIElementNode>();
        }
        
        public static void Export(Canvas targetCanvas)
        {
            if (targetCanvas == null)
            {
                Debug.LogError("Canvas가 비어있습니다!");
                return;
            }

            List<UIElementNode> rootNodes = new List<UIElementNode>();
            for (int i = 0; i < targetCanvas.transform.childCount; i++)
            {
                Transform child = targetCanvas.transform.GetChild(i);
                if (child == null)
                {
                    Debug.LogWarning($"Canvas의 자식 {i}가 null입니다.");
                    continue;
                }
                UIElementNode rootNode = BuildTree(child);
                if (rootNode == null)
                {
                    Debug.LogWarning("UI 트리 루트가 null입니다.");
                    return;
                }

                rootNodes.Add(rootNode);
            }

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(rootNodes, Formatting.Indented, settings);

            string path = Path.Combine(DataFolderSettings.GetDataFolderPath(), "UI_Hierarchy_Tree.json");
            File.WriteAllText(path, json);
            Debug.Log($"UI 트리 JSON이 저장됨: {path}");
        }

        private static UIElementNode BuildTree(Transform t)
        {
            string type = DetectType(t);
            if (type == null)
                return null;

            UIElementNode node = new UIElementNode();
            AddPropertiesByType(node, t);

            foreach (Transform child in t)
            {
                UIElementNode childNode = BuildTree(child);
                if (childNode != null)
                    node.children.Add(childNode);
            }

            return node;
        }

        private static string DetectType(Transform t)
        {
            if (t.GetComponent<Page>()) return "Page";
            if (t.GetComponent<InputFieldControl>()) return "InputField";
            if (t.GetComponent<SliderControl>()) return "Slider";
            if (t.GetComponent<ScrollPanelControl>()) return "ScrollPanel";
            if (t.GetComponent<VerticalPanelControl>()) return "VerticalPanel";
            if (t.GetComponent<HorizontalPanelControl>()) return "HorizontalPanel";
            if (t.GetComponent<GridPanelControl>()) return "GridPanel";
            if (t.GetComponent<ButtonControl>()) return "Button";
            if (t.GetComponent<PanelControl>()) return "Panel";
            if (t.GetComponent<TextControl>()) return "Text";
            if (t.GetComponent<ImageControl>()) return "Image";
            return null;
        }

        private static void AddPropertiesByType(UIElementNode node, Transform t)
        {
            if (t.GetComponent<Page>())
            {
                node.type = "Page";
                node.properties["name"] = t.name;
                return;
            }

            Component target = t.GetComponent<BaseControl>();
            if (target == null) return;

            var type = target.GetType();
            bool isControl = false;

            while (type != null && type != typeof(BaseControl).BaseType)
            {
                var props = type.GetProperties(
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.DeclaredOnly);

                foreach (var prop in props)
                {
                    if (!prop.CanRead) continue;
                    try
                    {
                        var value = prop.GetValue(target);
                        if (value != null)
                            node.properties[prop.Name] = value;
                    }
                    catch { }
                }

                if (!isControl)
                {
                    isControl = true;
                    node.type = type.Name.Replace("Control", "");
                }

                type = type.BaseType;
            }
        }
    }

}

