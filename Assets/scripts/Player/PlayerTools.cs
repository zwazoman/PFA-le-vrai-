using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// g�re les outils du joueur et leurs r�actions aux events du PlayerInputManager
/// </summary>
public class PlayerTools : MonoBehaviour
{
    PlayerInputManager _inputManager;
    [SerializeField] Hoe _hoe;
    [SerializeField] WateringCan _wateringCan;
    [SerializeField] Scythe _scythe;
    [SerializeField] Shovel _shovel;

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnHoe += Hoe;
        _inputManager.OnWateringCan += WateringCan;
        _inputManager.OnScythe += Scythe;
        _inputManager.OnShovel += Shovel;
    }

    /// <summary>
    /// r�agit a l'event OnHoe() de l'input manager et appelle Use() dans la classe Hoe
    /// </summary>
    private void Hoe()
    {
        print("Hoe");
        // lancer l'animation de l'outil
        _hoe.Use(); // pas n�cessaire si appel� dan sl'event de l'animation
    }

    /// <summary>
    /// r�agit a l'event OnWateringCan() de l'input manager et appelle Use() dans la classe WateringCan
    /// </summary>
    private void WateringCan()
    {
        print("WateringCan");
        // lancer l'animation de l'outil
        _wateringCan.Use();// pas n�cessaire si appel� dan sl'event de l'animation
    }

    /// <summary>
    /// r�agit a l'event OnScythe() de l'input manager et appelle Use() dans la classe Scythe
    /// </summary>
    private void Scythe()
    {
        print("Scythe");
        // lancer l'animation de l'outil
        _scythe.Use();// pas n�cessaire si appel� dan sl'event de l'animation
    }

    /// <summary>
    /// r�agit a l'event OnShovel() de l'input manager et appelle Use() dans la classe Shovel
    /// </summary>
    private void Shovel()
    {
        print("Shovel");
        // lancer l'animation de l'outil
        _shovel.Use();// pas n�cessaire si appel� dan sl'event de l'animation
    }
}
