using UnityEngine;
using UnityEngine.EventSystems;


public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _buttonSelect;
    public void resume()
    {
        UiManager.Instance.ActivateGameplayPanel();
    }

    private void OnEnable()
    {
        PlayerMain.Instance.Lock();
        EventSystem.current.SetSelectedGameObject(_buttonSelect);
    }

    private void OnDisable()
    {
        if(PlayerMain.Instance != null)
        PlayerMain.Instance.UnLock();
    }
}
