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
    [field : SerializeField]
    public bool EnterInterior { get; private set; }
    Volume fondu;
    private void Awake()
    {
        Arrivee = transform.Find("Arriv�e").gameObject;
        Assert.IsFalse(EnterInterior && otherTP.EnterInterior, "les deux tps m�nent vers l'int�rieur le fr�re");
        fondu = GameObject.Find("BlackVolume").GetComponent<Volume>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMain>(out PlayerMain player))
        {
            Assert.IsFalse(EnterInterior && otherTP.EnterInterior, "les deux tps m�nent vers l'int�rieur le fr�re");
            commencerFondu();
            //tp le joueur
            player.transform.position = otherTP.Arrivee.transform.position;
            player.Movement.SnapToGround();

            //fondu au noir

            //met le temps en pause ou le debloque selon si on rentre ou on sort ou pas
            if (EnterInterior)
            {
                //TimeManager.Instance.pauseTime();
                PlayerMain.Instance.OnEnterInterior.Invoke();
            }
            else if (otherTP.EnterInterior)
            {
                //TimeManager.Instance.resume();
                PlayerMain.Instance.OnExitInterior.Invoke();
            }

        }
    }

    private void commencerFondu()
    {
        CameraBehaviour.Instance.enabled = false;
        PlayerMain.Instance.Movement.enabled = false;

        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 0.5f, (float v) => fondu.weight = v,Nathan.SmoothStep01,finirFondu));
    }


    void finirFondu()
    {
        //---- l'�cran est tout noir ici ----

        CameraBehaviour.Instance.TeleportToTargetPosition();
        CameraBehaviour.Instance.enabled = true;

        //-----------------------------------

        StartCoroutine(Nathan.InterpolateOverTime(1, 0, 0.5f, (float v) => fondu.weight = v, Nathan.SmoothStep01, () => PlayerMain.Instance.Movement.enabled = true)) ;
    }

    
}
