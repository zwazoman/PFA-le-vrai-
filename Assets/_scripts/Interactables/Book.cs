using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Book : Interactable
{

    [SerializeField] GameObject _controlPanel;
    protected override void Interaction()
    {
        _controlPanel.SetActive(!_controlPanel.activeSelf);
    }
}
