using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Hoe()
    {
        print("Hoe");
        // lancer l'animation de l'outil
        _hoe.Use(); // pas nécessaire si appelé dan sl'event de l'animation
    }
    private void WateringCan()
    {
        print("WateringCan");
        // lancer l'animation de l'outil
        _wateringCan.Use();// pas nécessaire si appelé dan sl'event de l'animation
    }
    private void Scythe()
    {
        print("Scythe");
        // lancer l'animation de l'outil
        _scythe.Use();// pas nécessaire si appelé dan sl'event de l'animation
    }
    private void Shovel()
    {
        print("Shovel");
        // lancer l'animation de l'outil
        _shovel.Use();// pas nécessaire si appelé dan sl'event de l'animation
    }
}
