using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Game.Scripts.UI;

public static class PunkUIControlMenu
{
    private const string PrefabBasePath = "Assets/Prefabs/Punkland/";

    [MenuItem("GameObject/Punkland/Page", false, 1)]
    public static void CreatePage(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("Page.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/Panel", false, 2)]
    public static void CreatePanel(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("Panel.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/Button", false, 4)]
    public static void CreateButton(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("Button.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/Text", false, 4)]
    public static void CreateLabel(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("Text.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/Image", false, 4)]
    public static void CreateImage(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("Image.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/InputField", false, 4)]
    public static void CreateInputField(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("InputField.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/Slider", false, 4)]
    public static void CreateSlider(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("Slider.prefab", menuCommand);
    }
    
    [MenuItem("GameObject/Punkland/ScrollPanel", false, 3)]
    public static void CreateScrollPanel(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("ScrollPanel.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/HorizontalPanel", false, 3)]
    public static void CreateHorizontalPanel(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("HorizontalPanel.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/VerticalPanel", false, 3)]
    public static void CreateVerticalPanel(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("VerticalPanel.prefab", menuCommand);
    }

    [MenuItem("GameObject/Punkland/GridPanel", false, 3)]
    public static void CreateGridPanel(MenuCommand menuCommand)
    {
        InstantiateUIPrefab("GridPanel.prefab", menuCommand);
    }

    private static void InstantiateUIPrefab(string prefabFileName, MenuCommand menuCommand)
    {
        string fullPath = PrefabBasePath + prefabFileName;
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(fullPath);

        if (prefab == null)
        {
            Debug.LogError($"[PunklandUIBuilder] 프리팹이 존재하지 않습니다.: {fullPath}");
            return;
        }

        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        instance.name = "Punk" + prefab.name;
        GameObjectUtility.SetParentAndAlign(instance, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(instance, "Create " + prefab.name);
        Selection.activeGameObject = instance;
    }
}
