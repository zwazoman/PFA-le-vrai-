using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.Rendering;

public class introManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] charon_bateau bateau;
    [SerializeField] Transform playerSocket, cameraSocket;
    [SerializeField] string premierDialogueCharon;
    [SerializeField] Volume blackVolume;
    [SerializeField] Transform PlayerSpawn;

    [Header("AnimationParameters")]
    [SerializeField] float _animationDuration = 60;
    [SerializeField] AnimationCurve _boatMovementCurve;

    Task dialogueCharon;

    public static bool IsActive = false;

    private void Start()
    {
        UiManager.Instance.ActivateIntroPanel();

        TimeManager.Instance.pauseTime();
        UiManager.Instance.canPause = false;

        PlayerMain.Instance.InputManager.enabled = false;
        PlayerMain.Instance.Movement.enabled = false;
        PlayerMain.Instance.transform.position = playerSocket.position;
        PlayerMain.Instance.transform.parent = playerSocket;
        //PlayerMain.Instance.WheelBarrow.Movement.enabled = false;
        //PlayerMain.Instance.GetComponent<Collider>().enabled = false;


        CameraBehaviour.Instance.transform.parent = cameraSocket;
        CameraBehaviour.Instance.transform.localEulerAngles = Vector3.zero;
        CameraBehaviour.Instance.transform.localPosition = Vector3.zero;

        //fade from black
        StartCoroutine(Nathan.InterpolateOverTime(1, 0, 2.5f, (float a) => blackVolume.weight = a, Nathan.SmoothStep01));

        //movement bateau
        StartCoroutine(Nathan.InterpolateOverTime(1, 0.538f, _animationDuration, bateau.setPositionAlongCurve, (v) => { return _boatMovementCurve.Evaluate(v); }, sequence, false));
    }

    private void Awake()
    {
        IsActive = true;
        blackVolume.weight = 1;
    }

    async void sequence()
    {
        //premierDialogueCharon Charon
        await UiManager.Instance.PopupDialogue(premierDialogueCharon, this);

        //placement joueur sur quai puis lancement de la fin de la sequence
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 1,(float a)=>PlayerMain.Instance.transform.position = Vector3.Lerp(PlayerMain.Instance.transform.position,PlayerSpawn.position,a), (v) => { return Mathf.SmoothStep(0, 1, v); }, finSequence, false));

        //placement camera
        CameraBehaviour.Instance.enabled = true;
        CameraBehaviour.Instance.transform.parent = null;
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 3, UpdateCameraPosition,Nathan.SmoothStep01));

    }

    void UpdateCameraPosition(float a)
    {
       CameraBehaviour.Instance.transform.rotation = Quaternion.Lerp(CameraBehaviour.Instance.transform.rotation, Quaternion.Euler(45, 45, 0), a);
       CameraBehaviour.Instance.transform.position = Vector3.Lerp(CameraBehaviour.Instance.transform.position,CameraBehaviour.Instance.target.transform.position+CameraBehaviour.Instance.Offset, a);
    }

    void finSequence()
    {
        //reactiver le joueur
        PlayerMain.Instance.InputManager.enabled = true;
        PlayerMain.Instance.Movement.enabled = true;
        PlayerMain.Instance.transform.parent = null;
        UiManager.Instance.ActivateGameplayPanel();


        //depart bateau
        StartCoroutine(Nathan.InterpolateOverTime(0.538f,0 , TimeManager.Instance.IrlHourDuration*5, bateau.setPositionAlongCurve, (v) => { return _boatMovementCurve.Evaluate(v); }));

        //bateau.PartirPourDeVrai();
        TimeManager.Instance.OnHour += bateau.OnHour;

        //relancer le temps
        UiManager.Instance.canPause = true;
        TimeManager.Instance.resume();
    }
}
