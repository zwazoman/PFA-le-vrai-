using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGame : Interactable
{
    int _fishDurability;
    bool _catch;
    [SerializeField] float _minReflexTime;
    [SerializeField] float _maxRefelxTime;

    private void Start()
    {
        PlayerMain.Instance.InputManager.OnInteract += Fish;
    }

    protected override void Interaction()
    {
        PlayerMain.Instance.Movement.enabled = false; //désactive les mouvements du joueur
        //animation de con
        StartCoroutine(Fishing());
    }

    IEnumerator Fishing()
    {
        yield return new WaitForSeconds(Random.Range(3, 20));
        //animation de merde
        _catch = true;
        yield return new WaitForSeconds(Random.Range(_minReflexTime, _maxRefelxTime));
        //animation de salope
        _catch = false;
    }

    void Fish()
    {
        if (_catch)
        {

        }
    }
}
