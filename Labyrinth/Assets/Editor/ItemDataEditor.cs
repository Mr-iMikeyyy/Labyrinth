using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemList))]
public class ItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (ItemList)target;

        if (GUILayout.Button("Sort", GUILayout.Height(40)))
        {
            script.sort();
        }

    }
}
