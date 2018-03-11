// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// [CustomEditor(typeof(Enemy), true)]
// public class EnemyEditor : Editor {
//     private SerializedObject m_Object;
//     private SerializedProperty m_Property;

//     void OnEnable() {
//         m_Object = new SerializedObject(target);
//     }
    
//     public override void OnInspectorGUI()
//     {
//         base.OnInspectorGUI();
//         Enemy es = target as Enemy;

// 		EditorGUI.BeginDisabledGroup(!es.canShoot);
//         es.shootInterval = EditorGUILayout.FloatField("Shoot Interval", es.shootInterval);
//         es.bulletSpeed = EditorGUILayout.FloatField("Bullet Speed", es.bulletSpeed);
        
//         m_Property = m_Object.FindProperty("shootPoints");
//         EditorGUILayout.PropertyField(m_Property, new GUIContent("Shoot Points"), true);
//         m_Object.ApplyModifiedProperties();
        
//         EditorGUI.EndDisabledGroup();
//     }
// }
