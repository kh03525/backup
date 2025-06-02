#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class PzleDataMang : MonoBehaviour
{
    [MenuItem("Tools/Import HintData from JSON")]
    public static void ImportHintData()
    {
        string jsonPath = "Assets/YourPath/HINT3.json";  // JSON ���� ���
        string jsonText = System.IO.File.ReadAllText(jsonPath);

        string wrappedJson = "{\"entries\":" + jsonText + "}";

        HintEntryArray data = JsonUtility.FromJson<HintEntryArray>(wrappedJson);

        HintData hintDataAsset = ScriptableObject.CreateInstance<HintData>();
        hintDataAsset.entries = data.entries;

        AssetDatabase.CreateAsset(hintDataAsset, "Assets/YourPath/HintData.asset");
        AssetDatabase.SaveAssets();

        Debug.Log("HintData asset created.");
    }
}
#endif
