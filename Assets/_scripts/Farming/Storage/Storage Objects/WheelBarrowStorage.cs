using System;
using System.Collections;
using UnityEngine;


/// <summary>
/// stockage de la brouette
/// </summary>
public class WheelBarrowStorage : Storage
{
    [field : SerializeField] 
    public float MaxStorageWheelBarrow { get; set; }

    public event Action OnAdd;
    public event Action OnRemove;

    [SerializeField] GameObject _emptySocket;

    Collider coll;

    [SerializeField] AnimationCurve animationCurve;

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
        return storageContent.Count <= MaxStorageWheelBarrow;
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
        PlayerMain.Instance.GrabBox.ClearHands();

        //animation et UI
        OnAdd?.Invoke();
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, .55f, (float a) => { transform.localScale = Vector3.one * (100 + animationCurve.Evaluate(a)); }, (float a) => { return a; },()=>transform.localScale = Vector3.one*100));
    }

    /// <summary>
    /// dépile la liste du contenu de la brouette en faisant apparître et en plaçant les objets 1 par 1
    /// </summary>
    /// <returns></returns>
    public IEnumerator Empty()
    {
        PlayerMain.Instance.WheelBarrow.InputManager.OnEmpty -= () => StartCoroutine(Empty());
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 1.1f, (float a) => { transform.localScale = Vector3.one * (100 - animationCurve.Evaluate(a) * 1.6f); }, (float a) => { return a; }, () => transform.localScale = Vector3.one * 100));

        for (int i = storageContent.Count - 1; i >= 0; i--)
        {
            storageContent[i].transform.position = _emptySocket.transform.position;
            Detach(storageContent[i]);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f,0.35f));
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
        OnRemove?.Invoke();
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
