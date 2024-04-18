using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// component "Main" du joueur référençant toutes ses autres classes utilmisées comme components
/// </summary>
public class PlayerMain : MonoBehaviour
{
    [field : SerializeField]
    public Collider WheelBarrowCollider { get; private set; }

    [field : SerializeField]
    public Collider PlayerCollider { get; private set; }

    [field: SerializeField]
    public PlayerInputManager InputManager { get; private set; } // référence au component "PlayerInputManager" attaché au joueur

    [field: SerializeField]
    public PlayerMovement Movement { get; private set; }// référence au component "PlayerMovement" attaché au joueur

    [field : SerializeField]
    public PlayerInteraction Interaction { get; private set; }// référence au component "PlayerInteraction" attaché au joueur

    [field : SerializeField]
    public PlayerHands Hands { get; private set; }// référence au component "PlayerHands" attaché au joueur

    [field : SerializeField]
    public PlayerTools Tools { get; private set; }

    [field : SerializeField]
    public WheelBarrowMain WheelBarrow { get; private set; }

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
    }
}
