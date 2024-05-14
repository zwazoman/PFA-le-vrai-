using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGame : MonoBehaviour
{
    bool _catch = false;
    [SerializeField] float _reflexTime;
    [SerializeField] float _minWaitTime;
    [SerializeField] float _maxWaitTime;

    [SerializeField] List<GameObject> _fishes = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Fish();
        }
    }

    public void StartFishing()
    {
        //déplacer dans un autre script qui active celui là
        PlayerMain.Instance.InputManager.enabled = false; //désactive les mouvements du joueur
        //animation de con
        StartCoroutine(Fishing());
    }

    IEnumerator Fishing()
    {
        yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
        //animation de merde
        //son bien
        _catch = true;
        yield return new WaitForSeconds(_reflexTime);
        //animation de salope
        //son moins bien
        _catch = false;
        //sortir du mode pêche
    }

    void Fish()
    {
        if (_catch)
        {
            Fished();
        }
        else
        {
            StopFishing();
        }
    }

    void StopFishing()
    {
        StopCoroutine(Fishing());
        //d'autres trucs là
    }

    void Fished()
    {
        //donner le poisson
        StopFishing();
    }
}