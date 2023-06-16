﻿using BinaryEyes.Common.Data;
using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Drawers
{
    [CustomPropertyDrawer(typeof(Interval))]
    public class IntervalDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            if (indent > 0)
                position.x += 15.0f;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (indent > 0)
                position.x -= 15.0f;

            var rect = new Rect(position.x, position.y, position.width*0.46f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Min"), GUIContent.none);

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.04f, position.height);
            EditorGUI.LabelField(rect, "");

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.5f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Max"), GUIContent.none);

            EditorGUI.EndProperty();
            EditorGUI.indentLevel = indent;
        }
    }
}