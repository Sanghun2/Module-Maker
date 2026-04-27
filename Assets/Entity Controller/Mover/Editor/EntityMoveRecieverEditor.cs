using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityMoveRecieverBase), true)]
public class EntityMoveRecieverEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var _script = (EntityMoveRecieverBase)target;
        if (GUILayout.Button("Connect Source")) {
            _script.TryConnectMoveSource();
        }
    }
}
