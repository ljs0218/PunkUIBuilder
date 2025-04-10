using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class DataFolderSettings
{
    private const string DataFolderKey = "MyProject_DataFolderPath";

    static DataFolderSettings()
    {
        EditorApplication.update += CheckAndPrompt;
    }

    private static void CheckAndPrompt()
    {
        EditorApplication.update -= CheckAndPrompt;

        if (!EditorPrefs.HasKey(DataFolderKey))
        {
            PromptForFolder();
        }
    }

    private static void PromptForFolder()
    {
        string path = EditorUtility.OpenFolderPanel("데이터 저장 폴더 선택", Application.dataPath, "");
        if (!string.IsNullOrEmpty(path))
        {
            EditorPrefs.SetString(DataFolderKey, path);
            Debug.Log($"데이터 저장 폴더가 설정되었습니다: {path}");
        }
        else
        {
            Debug.LogWarning("데이터 저장 폴더가 설정되지 않았습니다.");
        }
    }

    [MenuItem("Tools/데이터 저장 폴더 설정")]
    private static void ChangeDataFolder()
    {
        string currentPath = EditorPrefs.GetString(DataFolderKey, Application.dataPath);
        string newPath = EditorUtility.OpenFolderPanel("데이터 저장 폴더 변경", currentPath, "");
        if (!string.IsNullOrEmpty(newPath))
        {
            EditorPrefs.SetString(DataFolderKey, newPath);
            Debug.Log($"데이터 저장 폴더가 변경되었습니다: {newPath}");
        }
    }

    public static string GetDataFolderPath()
    {
        return EditorPrefs.GetString(DataFolderKey, Application.dataPath);
    }
}
