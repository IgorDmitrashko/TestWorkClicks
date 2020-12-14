using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeometryObjectData))]
public class GeometryObjectDataEditor : Editor
{
    private GeometryObjectData _geometryObjectData;

    private void Awake() {
        _geometryObjectData = (GeometryObjectData)target;
    }

    public override void OnInspectorGUI() {
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("RemoveAll"))
        {
            _geometryObjectData.ClearClickData();
        }

        if(GUILayout.Button("Remove"))
        {
            _geometryObjectData.RemoveCurrentElement();
        }

        if(GUILayout.Button("Add"))
        {
            _geometryObjectData.AddElement();
        }

        if(GUILayout.Button("<="))
        {
            _geometryObjectData.GetPrevious();
        }

        if(GUILayout.Button("=>"))
        {
            _geometryObjectData.GetNext();
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
