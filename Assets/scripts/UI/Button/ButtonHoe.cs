using UnityEngine;

public class ButtonHoe : MonoBehaviour
{
    [SerializeField] ButtonJuice _juiceHoe;
    [SerializeField] ButtonJuice _juiceWateringCan;
    [SerializeField] ButtonJuice _juiceShovel;
    [SerializeField] ButtonJuice _juiceScythe;

    void Start()
    {
        PlayerMain.Instance.InputManager.OnHoe += _juiceHoe.ButtonScale;

        PlayerMain.Instance.InputManager.OnWateringCan += _juiceWateringCan.ButtonScale;

        PlayerMain.Instance.InputManager.OnShovel += _juiceShovel.ButtonScale;

        PlayerMain.Instance.InputManager.OnScythe += _juiceScythe.ButtonScale;
    }
}
