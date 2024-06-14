using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// component "Main" du joueur référençant toutes ses autres classes utilmisées comme components
/// </summary>
public class PlayerMain : MonoBehaviour
{
    [field: SerializeField]
    public PlayerInputManager InputManager { get; private set; } // référence au component "PlayerInputManager" attaché au joueur

    [field: SerializeField]
    public WheelBarrowInputManager WBInputManager { get; private set; } // référence au component "PlayerInputManager" attaché au joueur

    [field: SerializeField]
    public PlayerMovement Movement { get; private set; }// référence au component "PlayerMovement" attaché au joueur
    
    [field: SerializeField]
    public PlayerVisuals Visuals { get; private set; }

    [field : SerializeField]
    public PlayerSounds Sounds { get; private set; }

    [field : SerializeField]
    public PlayerInteraction Interaction { get; private set; }// référence au component "PlayerInteraction" attaché au joueur

    [field : SerializeField]
    public PlayerHands Hands { get; private set; }// référence au component "PlayerHands" attaché au joueur

    [field : SerializeField]
    public PlayerTools Tools { get; private set; }

    [field : SerializeField]
    public PlayerGrabBox GrabBox { get; private set; }

    [field : SerializeField]
    public WheelBarrowMain WheelBarrow { get; private set; }

    [field: SerializeField]
    public PlayerStats Stats { get; private set; }

    [field: SerializeField]
    public WateringStorage Watering { get; private set; }

    [field : SerializeField]
    public WateringCan Can { get; private set; }

    [field: SerializeField]
    public DialogueInputManager DialogueInput {  get; private set; }

    [field: SerializeField]
    public AmbienceManager Ambience { get; private set; }

    [field: SerializeField]
    public ItemTag Tag { get; private set; }

    [field : SerializeField]
    public GroundEffect GroundEffect { get; private set; }

    [field : SerializeField]
    public playerAnimationEventReceiver AnimationEventReceiver { get; private set; }

    public Transform WheelBarrowSocket;

    public UnityEvent OnEnterInterior;
    public UnityEvent OnExitInterior;


    public bool isLocked = false;
    List<MonoBehaviour> lockedBehaviours = new();

    public void Lock()
    {
        //if (isLocked) return;
        //foreach (MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponentsInChildren<MonoBehaviour>()) 
        //{
        //    if (mb.enabled)
        //    {
        //        lockedBehaviours.Add(mb);
        //        mb.enabled = false;
        //    }

        //}
        //isLocked = true;
        PlayerMain.Instance.InputManager.enabled = false;
        PlayerMain.instance.WheelBarrow.InputManager.enabled = false;
    }

    public void UnLock()
    {
        //foreach (MonoBehaviour mb in lockedBehaviours)
        //{
        //    mb.enabled = true;
        //}

        //isLocked = false;
        //lockedBehaviours.Clear();
        PlayerMain.instance.InputManager.enabled = true;
        PlayerMain.instance.WheelBarrow.InputManager.enabled = true;
    }

    //singleton
    private static PlayerMain instance = null;
    public static PlayerMain Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        Cursor.visible = false; //Cursor devient invisible
    }
}
