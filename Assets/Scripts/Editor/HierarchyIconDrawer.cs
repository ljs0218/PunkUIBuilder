using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Game.Scripts.UI;

[InitializeOnLoad]
public static class HierarchyTypeLabelDrawer
{
    static HierarchyTypeLabelDrawer()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj == null) return;

        string label = GetTypeLabel(obj);
        if (string.IsNullOrEmpty(label)) return;

        // 텍스트 스타일 설정
        GUIStyle style = new GUIStyle(EditorStyles.label);
        style.normal.textColor = new Color32(145, 129, 255, 255);
        style.fontSize = 10;
        style.alignment = TextAnchor.MiddleRight;

        if (label == "Page")
        {
            Texture2D icon = EditorGUIUtility.Load("Assets/Editor/Icons/Folder.png") as Texture2D;
            if (icon != null)
            {
                Rect iconRect = new Rect(selectionRect.xMax - 16 - 34, selectionRect.y, 16, 16);
                GUI.DrawTexture(iconRect, icon);
            }

            style.normal.textColor = new Color32(255, 255, 255, 255);
        }

        // 텍스트 위치 설정 (이름 오른쪽에 띄우기)
        Rect r = new Rect(selectionRect);
        r.xMin = r.xMax - 70; // 오른쪽 정렬
        GUI.Label(r, $"[{label}]", style);
    }

    private static string GetTypeLabel(GameObject obj)
    {
        // 순서 중요: 구체적인 타입부터
        if (obj.GetComponent<Page>()) return "Page";
        if (obj.GetComponent<ScrollPanelControl>()) return "ScrollPanel";
        if (obj.GetComponent<VerticalPanelControl>()) return "VerticalPanel";
        if (obj.GetComponent<HorizontalPanelControl>()) return "HorizontalPanel";
        if (obj.GetComponent<GridPanelControl>()) return "GridPanel";
        if (obj.GetComponent<ButtonControl>()) return "Button";
        if (obj.GetComponent<TextControl>()) return "Text";
        if (obj.GetComponent<ImageControl>()) return "Image";
        if (obj.GetComponent<PanelControl>()) return "Panel";
        if (obj.GetComponent<ViewportControl>()) return "Viewport";
        if (obj.GetComponent<Control>()) return "Control";
        return null;
    }
}
