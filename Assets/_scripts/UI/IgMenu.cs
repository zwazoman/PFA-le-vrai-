using UnityEngine;

public class IgMenu : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    

    private void Start()
    {
        PlayerMain.Instance.InputManager.OnPause += PauseMenu;
    }

    void PauseMenu()
    {
        _pausePanel.SetActive(true);
    }
}
