using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        MapGenerator mapGenerator = (MapGenerator)target;
        if (DrawDefaultInspector() && mapGenerator.AutoReGenerate == true)
        {
            mapGenerator.GeneratorMap();
        }
        if (GUILayout.Button("Generate"))
        {
            mapGenerator.GeneratorMap();
        }
    }
}
