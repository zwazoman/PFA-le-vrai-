using CustomInspector;
using CustomInspector.Extensions;
using System;
using UnityEditor;
using UnityEngine;

namespace CustomInspector.Editor
{

    [CustomPropertyDrawer(typeof(StringChoiceAttribute))]
    public class StringChoiceAttributeDrawer : PropertyDrawer
    {
        static bool isGlobalDisabled = false;
        //public string[] options = new string[] { "Cube", "Sphere", "Plane" }; // ça sera une variable statique dans le script qui scannera le dir. des dialogues
        int index;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
           /* if (!isGlobalDisabled)
            {
                //finds the index of the currently selected item in the list
                index = 0;
                for(int i = 0;i< DialogueDirectory.)
                {
                    
                    if (option == property.stringValue) break;
                    index++;
                }


                //updates the propertie
                property.serializedObject.Update();
                index =EditorGUILayout.Popup("Dialogue ", index, DialogueDirectory.FileNames);
                property.stringValue = DialogueDirectory.FileNames[index];
                property.serializedObject.ApplyModifiedProperties();
            }*/
        }
        /*public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!isGlobalDisabled)
            {
                if (property.IsArrayElement())
                    return DrawProperties.messageBoxHeight;
                else
                    return -EditorGUIUtility.standardVerticalSpacing;
            }
            else
            {
                return DrawProperties.GetPropertyHeight(label, property);
            }
        }*/

        public class GlobalDisable : IDisposable
        {
            public GlobalDisable() => isGlobalDisabled = true;
            public void Dispose() => isGlobalDisabled = false;
        }
    }
}