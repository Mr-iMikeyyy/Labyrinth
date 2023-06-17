using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DevCheats))]
public class DevCheatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (DevCheats)target;

        if (GUILayout.Button("Teleport to Center", GUILayout.Height(40)))
        {
            script.TeleportToCenter();
        }

        if (GUILayout.Button("Full Heal", GUILayout.Height(40)))
        {
            script.FullHeal();
        }


        if (GUILayout.Button("+ Max HP", GUILayout.Height(40)))
        {
            script.IncreaseMaxHP();
        }

        if (GUILayout.Button("- Max HP", GUILayout.Height(40)))
        {
            script.DecreaseMaxHP();
        }


        if (GUILayout.Button("DO NOT PRESS", GUILayout.Height(40)))
        {
            script.WarnedYou();
        }
    }
}
