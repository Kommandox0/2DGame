using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Collisions))]
public class CollisionsInspector : Editor
{
    static bool stats = true;
    static bool baseInspector = true;

    public override void OnInspectorGUI()
    {
        Collisions coll = (Collisions)target;

        baseInspector = EditorGUILayout.Foldout(baseInspector, "Base Inspector", true, EditorStyles.toolbarDropDown);

        if(baseInspector)
        {
            base.OnInspectorGUI();
        }

        stats = EditorGUILayout.Foldout(baseInspector, "Stats", true, EditorStyles.toolbarDropDown);

        if(stats)
        {

        }
    }
}
