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

    private void Update()
    {
        if (_controlPanel.activeSelf && (PlayerMain.Instance.transform.position - transform.position).sqrMagnitude > 25)
        {
            _controlPanel.SetActive(false);
        }
    }
}
