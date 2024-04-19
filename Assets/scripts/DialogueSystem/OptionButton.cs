using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button btn;
    public void SetUp(string optionName, UnityAction callback)
    {
        text.text = optionName;
        btn.onClick.AddListener(callback);
    }
}
