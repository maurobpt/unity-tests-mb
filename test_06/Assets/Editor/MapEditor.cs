using System.Collections;
using System.Collections.Generic;
using UnityEditor;
[CustomEditor (typeof (MapGenerator))]
public class MapEditor : Editor
{
    //Update in real time actions from outlinePercent 
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapGenerator map = target as MapGenerator;

        map.GenerateMap();
    }
}
