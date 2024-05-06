using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Rendering;

/// <summary>
///permet de faire se tp le joueur rentrant dans le trigger vers un autre tp
/// </summary>
public class TP : MonoBehaviour
{

    [SerializeField] TP otherTP;
    [HideInInspector] public GameObject Arrivee;
    public bool pauseTimeWhenActivated = false;
    Volume fondu;
    private void Awake()
    {
        Arrivee = transform.Find("Arrivée").gameObject;
        Assert.IsFalse(pauseTimeWhenActivated && otherTP.pauseTimeWhenActivated, "les deux tp mettent le temps en pause,il y'a un probleme. couillon va");
        fondu = GameObject.Find("BlackVolume").GetComponent<Volume>();
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.TryGetComponent<PlayerMain>(out PlayerMain player))
        {
            Assert.IsFalse(pauseTimeWhenActivated && otherTP.pauseTimeWhenActivated, "les deux tp mettent le temps en pause,il y'a un probleme. couillon va");
            commencerFondu();
            //tp le joueur
            player.transform.position = otherTP.Arrivee.transform.position;

            //fondu au noir

            //met le temps en pause ou le debloque selon si on rentre ou on sort
            if (pauseTimeWhenActivated)
            {
                TimeManager.Instance.pauseTime();
            }
            else if (otherTP.pauseTimeWhenActivated)
            {
                TimeManager.Instance.resume();
            }

        }
    }

    private void commencerFondu()
    {
        CameraBehaviour.Instance.enabled = false;
        PlayerMain.Instance.Movement.enabled = false;

        StartCoroutine(Tooling.InterpolateOverTime(0, 1, 0.5f, (float v) => fondu.weight = v,Tooling.SmoothStep,finirFondu));
    }


    void finirFondu()
    {
        //---- l'écran est tout noir ici ----

        CameraBehaviour.Instance.TeleportToTargetPosition();
        CameraBehaviour.Instance.enabled = true;

        //-----------------------------------

        StartCoroutine(Tooling.InterpolateOverTime(1, 0, 0.5f, (float v) => fondu.weight = v, Tooling.SmoothStep, () => PlayerMain.Instance.Movement.enabled = true)) ;
    }

    
}
