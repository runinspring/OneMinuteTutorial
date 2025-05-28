using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
public class RenamePlugin : EditorWindow
{
    [MenuItem("One Minute Tutorial/RenamePlugin")]
    static void OnShow()
    {
        RenamePlugin myWindow = (RenamePlugin)EditorWindow.GetWindow(typeof(RenamePlugin), false, "RenemaPlugin", true);
        myWindow.Show();
    }
    static string fixed_name = "MyObject_";
    static int index_start=0;
    void OnGUI()
    {
        GUILayout.Label("Fixed Name:");
        fixed_name = EditorGUILayout.TextArea(fixed_name, GUILayout.Width(90));
        GUILayout.Label("Index Start:");
        index_start = int.Parse(GUILayout.TextArea(index_start.ToString(), GUILayout.Width(30)));

        var selectObjects = Selection.gameObjects.OrderBy(_ => _.transform.GetSiblingIndex());
        int i = 0;
        foreach (var obj in selectObjects)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"selected: {obj.name} --> Changed Name: {fixed_name}{index_start + i}");
            EditorGUILayout.EndHorizontal();
            i++;
        }

        if (GUILayout.Button("Rename", GUILayout.Width(90)))
        {
            int j = 0;
            foreach (var obj in selectObjects)
            {
                obj.name = $"{fixed_name}{index_start + j}";
                j++;
            }
        
        }
    }
}
