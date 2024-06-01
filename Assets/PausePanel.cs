using UnityEngine;


public class PausePanel : MonoBehaviour
{
    public void resume()
    {
        UiManager.Instance.ActivateGameplayPanel();
    }

    private void OnEnable()
    {
        PlayerMain.Instance.Lock();

    }

    private void OnDisable()
    {
        if(PlayerMain.Instance != null)
        PlayerMain.Instance.UnLock();
    }
}
