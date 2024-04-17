using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


/// <summary>
/// stockage de la brouette
/// </summary>
public class WheelBarrowStorage : Storage
{
    [field : SerializeField] 
    public float _maxStorageWheelBarrow { get; set; }

    [SerializeField] float _distanceToEmpty;
    [SerializeField] float _hightToEmpty;

    private void Start()
    {
        PlayerMain.Instance.WheelBarrow.InputManager.OnEmpty += () => StartCoroutine(Empty());
    }

    protected override bool CanAbsorb(Item item)
    {
        return storageContent.Count <= _maxStorageWheelBarrow;
    }

    /// <summary>
    /// d�sactive un objet et le t�l�porte au dessus de la brouette quand l'objet tombe dans la brouette
    /// </summary>
    /// <param name="item"></param>
    protected override void OnAbsorb(GameObject item)
    {
        item.SetActive(false);
        item.transform.parent = transform;
        item.transform.position = transform.position + Vector3.up;
    }

    /// <summary>
    /// d�pile la liste du contenu de la brouette en faisant appar�tre et en pla�ant les objets 1 par 1
    /// </summary>
    /// <returns></returns>
    public IEnumerator Empty()
    {
        for (int i = storageContent.Count - 1; i >= 0; i--)
        {
            storageContent[i].transform.position = transform.position + transform.forward * _distanceToEmpty + Vector3.up * _hightToEmpty;
            storageContent[i].transform.parent = null;
            storageContent[i].SetActive(true);
            storageContent.Remove(storageContent[i]);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
