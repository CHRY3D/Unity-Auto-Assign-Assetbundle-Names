using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(assignAssetbundles))]
public class assignAssetbundlesEditor : Editor {
    private GameObject[] prefabs;
    private string dest;
    private string targ;
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        assignAssetbundles vars = (assignAssetbundles)target;
        if (GUILayout.Button("Fetch Prefabs [Assets/Resources/Prefabs]")) {
            getPrefabs();
        }
        if (GUILayout.Button("Build Prefabs [Assets/Resources/$Destination]")) {
            createDirectory();
        }
        
        void getPrefabs() {
            vars.prefabs = Resources.LoadAll<GameObject>("Prefabs");
        }

        void createDirectory() {
            dest = vars.destination;
            if (string.IsNullOrEmpty(dest)) {
                dest = "Output";
                AssetDatabase.CreateFolder("Assets/Resources", dest);
                assignAssetbundleNames();
            } else {
                AssetDatabase.CreateFolder("Assets/Resources", dest);
                assignAssetbundleNames();
            }
        }

        void assignAssetbundleNames() {
            foreach(GameObject prefab in vars.prefabs) {
                GameObject temp = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
                temp.name = prefab.name;
                PrefabUtility.SaveAsPrefabAssetAndConnect(temp, "Assets/Resources/" + dest + "/" + temp.gameObject.name + ".prefab", InteractionMode.UserAction);
                AssetImporter.GetAtPath("Assets/Resources/" + dest + "/" + temp.gameObject.name + ".prefab").SetAssetBundleNameAndVariant(temp.gameObject.name, "");
                DestroyImmediate(temp);
            }
        }
    }
}