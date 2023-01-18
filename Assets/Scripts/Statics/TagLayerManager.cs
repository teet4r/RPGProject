using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TagLayerManager : MonoBehaviour
{
    /// <summary> �±� �ߺ� Ȯ�� �� �߰� </summary>
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void AddNewTag(string tagName)
    {
#if UNITY_EDITOR
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");

        int tagCount = tagsProp.arraySize;

        // [1] �ش� �±װ� �����ϴ��� Ȯ��
        bool found = false;
        for (int i = 0; i < tagCount; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);

            if (t.stringValue.Equals(tagName))
            {
                found = true;
                break;
            }
        }

        // [2] �迭 �������� �±� �߰�
        if (!found)
        {
            tagsProp.InsertArrayElementAtIndex(tagCount);
            SerializedProperty n = tagsProp.GetArrayElementAtIndex(tagCount);
            n.stringValue = tagName;
            tagManager.ApplyModifiedProperties();
        }
#endif
    }

    /// <summary> ���̾� �ߺ� Ȯ�� �� �߰� </summary>
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void AddNewLayer(string layerName)
    {
#if UNITY_EDITOR
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty layersProp = tagManager.FindProperty("layers");

        int layerCount = layersProp.arraySize;
        int targetIndex = -1;

        // [1] �ش� ���̾ �����ϴ��� Ȯ��
        // NOTE : 0 ~ 7������ Buit-in Layer �����̹Ƿ� ����
        for (int i = 8; i < layerCount; i++)
        {
            SerializedProperty t = layersProp.GetArrayElementAtIndex(i);
            string strValue = t.stringValue;

            // �� ���̾� ������ ã�� ���
            if (targetIndex == -1 && string.IsNullOrWhiteSpace(strValue))
            {
                targetIndex = i;
            }

            // �̹� �ش� ���̾� �̸��� ������ ���
            else if (strValue.Equals(layerName))
            {
                targetIndex = -1;
                break;
            }
        }

        // [2] �� ������ ���̾� �߰�
        if (targetIndex != -1)
        {
            SerializedProperty n = layersProp.GetArrayElementAtIndex(targetIndex);
            n.stringValue = layerName;
            tagManager.ApplyModifiedProperties();
        }
#endif
    }

    public static void AddTag(string tag)
    {
        var asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        if ((asset != null) && (asset.Length > 0))
        {
            SerializedObject so = new SerializedObject(asset[0]);
            SerializedProperty tags = so.FindProperty("tags");

            for (int i = 0; i < tags.arraySize; ++i)
            {
                if (tags.GetArrayElementAtIndex(i).stringValue == tag)
                {
                    return;     // Tag already present, nothing to do.
                }
            }

            tags.InsertArrayElementAtIndex(tags.arraySize - 1);
            tags.GetArrayElementAtIndex(tags.arraySize - 1).stringValue = tag;
            so.ApplyModifiedProperties();
            so.Update();
        }
        AssetDatabase.SaveAssets();
    }
}
