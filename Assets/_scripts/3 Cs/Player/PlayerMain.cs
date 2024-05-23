using UnityEngine;

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

    public Transform WheelBarrowSocket;


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
        Cursor.visible = false;
    }
}
