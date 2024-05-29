using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadText : MonoBehaviour
{
    [SerializeField] TMP_Text _textLoad;


    void Start()
    {
        StartCoroutine(ChangeText());
    }

IEnumerator ChangeText()
    {
        _textLoad.text = "Chargement.";
        yield return new WaitForSeconds(0.5f);
        _textLoad.text = "Chargement..";
        yield return new WaitForSeconds(0.5f);
        _textLoad.text = "Chargement...";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ChangeText());
    }
}
