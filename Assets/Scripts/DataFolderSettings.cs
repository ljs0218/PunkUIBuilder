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
        string path = EditorUtility.OpenFolderPanel("������ ���� ���� ����", Application.dataPath, "");
        if (!string.IsNullOrEmpty(path))
        {
            EditorPrefs.SetString(DataFolderKey, path);
            Debug.Log($"������ ���� ������ �����Ǿ����ϴ�: {path}");
        }
        else
        {
            Debug.LogWarning("������ ���� ������ �������� �ʾҽ��ϴ�.");
        }
    }

    [MenuItem("Tools/������ ���� ���� ����")]
    private static void ChangeDataFolder()
    {
        string currentPath = EditorPrefs.GetString(DataFolderKey, Application.dataPath);
        string newPath = EditorUtility.OpenFolderPanel("������ ���� ���� ����", currentPath, "");
        if (!string.IsNullOrEmpty(newPath))
        {
            EditorPrefs.SetString(DataFolderKey, newPath);
            Debug.Log($"������ ���� ������ ����Ǿ����ϴ�: {newPath}");
        }
    }

    public static string GetDataFolderPath()
    {
        return EditorPrefs.GetString(DataFolderKey, Application.dataPath);
    }
}
