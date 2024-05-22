using System.Collections;
using UnityEngine;


/// <summary>
/// stockage de la brouette
/// </summary>
public class WheelBarrowStorage : Storage
{
    [field : SerializeField] 
    public float _maxStorageWheelBarrow { get; set; }

    [SerializeField] GameObject _emptySocket;

    Collider coll;

    private void Awake()
    {
        coll = GetComponent<Collider>();
    }

    private void Start()
    {
        PlayerMain.Instance.WheelBarrow.InputManager.OnEmpty += () => StartCoroutine(Empty());
    }

    protected override bool CanAbsorb(Item item)
    {
        return storageContent.Count <= _maxStorageWheelBarrow;
    }

    /// <summary>
    /// désactive un objet et le téléporte au dessus de la brouette quand l'objet tombe dans la brouette
    /// </summary>
    /// <param name="item"></param>
    protected override void OnAbsorb(GameObject item)
    {
        item.SetActive(false);
        item.transform.parent = transform;
        item.transform.position = transform.position + Vector3.up;
    }

    /// <summary>
    /// dépile la liste du contenu de la brouette en faisant apparître et en plaçant les objets 1 par 1
    /// </summary>
    /// <returns></returns>
    public IEnumerator Empty()
    {
        PlayerMain.Instance.WheelBarrow.InputManager.OnEmpty -= () => StartCoroutine(Empty());
        for (int i = storageContent.Count - 1; i >= 0; i--)
        {
            storageContent[i].transform.position = _emptySocket.transform.position;
            Detach(storageContent[i]);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        }
        PlayerMain.Instance.WheelBarrow.InputManager.OnEmpty += () => StartCoroutine(Empty());
    }

    public void EmptyInHands()
    {
        if (storageContent.Count == 0) return;
        GameObject lastObject = storageContent[storageContent.Count - 1];
        Detach(lastObject);
        PlayerMain.Instance.Hands.Pickup(lastObject.GetComponent<Item>());
    }

    private void Detach(GameObject objectToEject)
    {
        objectToEject.transform.parent = null;
        objectToEject.SetActive(true);
        storageContent.Remove(objectToEject);
    }

    public void DisableStorage()
    {
        coll.enabled = false;
    }

    public void EnableStorage()
    {
        coll.enabled = true;
    }
}
