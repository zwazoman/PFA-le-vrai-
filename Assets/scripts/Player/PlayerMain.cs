using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// component "Main" du joueur r�f�ren�ant toutes ses autres classes utilmis�es comme components
/// </summary>
public class PlayerMain : MonoBehaviour
{
    [field : SerializeField]
    public Collider WheelBarrowCollider { get; private set; }

    [field : SerializeField]
    public Collider PlayerCollider { get; private set; }

    [field: SerializeField]
    public PlayerInputManager InputManager { get; private set; } // r�f�rence au component "PlayerInputManager" attach� au joueur

    [field: SerializeField]
    public PlayerMovement Movement { get; private set; }// r�f�rence au component "PlayerMovement" attach� au joueur

    [field : SerializeField]
    public PlayerInteraction Interaction { get; private set; }// r�f�rence au component "PlayerInteraction" attach� au joueur

    [field : SerializeField]
    public PlayerHands Hands { get; private set; }// r�f�rence au component "PlayerHands" attach� au joueur

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
