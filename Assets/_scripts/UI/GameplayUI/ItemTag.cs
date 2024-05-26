using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    [SerializeField] GameObject _itemTagframe;
    [SerializeField] TMP_Text _tagText;

    public void Showtag(string itemName)
    {
        _itemTagframe.SetActive(true);
        _tagText.text = itemName;
    }

    //IEnumerator Show()
    //{
    //    _itemTagframe.SetActive(true);
    //    yield return new WaitForSeconds(3);
    //    _itemTagframe.SetActive(false);
    //}

    public void Hidetag()
    {
        _itemTagframe.SetActive(false);
        _tagText.text = null;
    }
}
