using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace CustomInspector.Editor
{
    /// <summary>
    /// Hides the field in the inspector but not attributes attached to it
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [Conditional("UNITY_EDITOR")]
    public class StringChoiceAttribute : PropertyAttribute
    {
        public StringChoiceAttribute() => order = 1;
    }
}