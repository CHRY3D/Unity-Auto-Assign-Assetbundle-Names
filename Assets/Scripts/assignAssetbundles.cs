using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignAssetbundles : MonoBehaviour {
    [Header("")]
    [Header("Set a destination (folder name) and hit [Build Prefabs]")]
    [Header("Usage: Put prefabs in Assets/Resources/Prefabs, hit [Fetch Prefabs]")]
    [Header("")]
    [Header("Generates prefabs with assetbundle names from gameobject.name")]
    [Header("This utility can overwrite files, use with caution!")]

    public string destination;
    public GameObject[] prefabs;

}