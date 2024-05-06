using UnityEngine;


public class PausePanel : MonoBehaviour
{
    public void resume()
    {
        UiManager.Instance.ActivateGameplayPanel();
    }
}
