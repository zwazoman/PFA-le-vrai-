using UnityEngine;

public class IgMenu : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    

    private void Start()
    {
        PlayerMain.Instance.InputManager.OnPause += UiManager.Instance.ActivatePausePanel;
    }
}
