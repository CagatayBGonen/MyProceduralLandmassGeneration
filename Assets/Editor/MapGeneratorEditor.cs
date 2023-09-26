using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Bu class'in bir customeditor oldugunu ve type'nin MapGenerator oldugunu belirtmemiz gerekiyor.
[CustomEditor(typeof(MapGenerator))] //bunu yazmasaniz dugme gozukmez.
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Mapgenerator'un referanci alliyoruz.
        MapGenerator mapGenerator = (MapGenerator)target;

        //Draws the default inspector.
        DrawDefaultInspector();

        //inspector icindeki Generate buttonuna basildiginda, MapGenerator classindaki GenerateMap Metodunu calistir.
        if (GUILayout.Button("Generate"))
        {
            mapGenerator.GenerateMap();
        }
    }
}
