using UnityEngine;


public class PausePanel : MonoBehaviour
{
    public void resume()
    {
        UiManager.Instance.ActivateGameplayPanel();
    }

    private void OnEnable()
    {
        PlayerMain.Instance.Movement.enabled = false;
    }

    private void OnDisable()
    {
        if(PlayerMain.Instance != null)
        PlayerMain.Instance.Movement.enabled = true;
    }
}
