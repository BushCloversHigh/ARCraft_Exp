using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (ColorBlockUISetting))]
public class ColorBlockUISettingEditor : Editor
{
    public override void OnInspectorGUI ()
    {
        base.OnInspectorGUI ();

        ColorBlockUISetting setting = target as ColorBlockUISetting;

        if (GUILayout.Button ("GenerateBlockButtons"))
        {
            setting.GenerateBlockButtons ();
        }

    }
}
