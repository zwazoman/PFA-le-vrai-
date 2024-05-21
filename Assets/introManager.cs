using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.LowLevel;

public class introManager : MonoBehaviour
{
    [SerializeField] charon_bateau bateau;
    [SerializeField] Transform playerSocket, cameraSocket;
    [SerializeField] string dialogue;
    private void Start()
    {
        TimeManager.Instance.pauseTime();

        PlayerMain.Instance.InputManager.enabled = false;
        PlayerMain.Instance.Movement.enabled = false;
        PlayerMain.Instance.transform.position = playerSocket.position;
        PlayerMain.Instance.transform.parent = playerSocket;
        PlayerMain.Instance.GetComponent<Collider>().enabled = false;


        CameraBehaviour.Instance.enabled = true;
        CameraBehaviour.Instance.transform.parent = cameraSocket;
        CameraBehaviour.Instance.transform.localEulerAngles = Vector3.zero;
        CameraBehaviour.Instance.transform.localPosition = Vector3.zero;

        StartCoroutine(Nathan.InterpolateOverTime(1, 0.329f, 10, bateau.setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, sequence, false));
    }

    async void sequence()
    {

        await UiManager.Instance.PopupDialogue(dialogue, this);

        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 1,(float a)=>PlayerMain.Instance.transform.position = Vector3.Lerp(PlayerMain.Instance.transform.position,bateau.charon.SpawnSocket.position,a), (v) => { return Mathf.SmoothStep(0, 1, v); }, finSequence, false));

        CameraBehaviour.Instance.enabled = true;
        CameraBehaviour.Instance.transform.parent = null;

        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 1, UpdateCameraPosition,Nathan.SmoothStep01));

    }

    void UpdateCameraPosition(float a)
    {
        CameraBehaviour.Instance.transform.rotation = Quaternion.Lerp(CameraBehaviour.Instance.transform.rotation, Quaternion.Euler(45, 45, 0), a);
       CameraBehaviour.Instance.transform.position = Vector3.Lerp(CameraBehaviour.Instance.transform.position,CameraBehaviour.Instance.target.transform.position+CameraBehaviour.Instance.Offset, a);
    }

    public void finSequence()
    {
        PlayerMain.Instance.InputManager.enabled = true;
        PlayerMain.Instance.Movement.enabled = true;
        
        PlayerMain.Instance.transform.parent = null;
        TimeManager.Instance.resume();
        
        
        StartCoroutine(Nathan.InterpolateOverTime(0.329f, 0, 4, bateau.setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, () => { PlayerMain.Instance.GetComponent<Collider>().enabled = true; }, true));
    }
}
