using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Permet de gerer les scenes
/// </summary>
public class SwitchScene : MonoBehaviour
{
    public void GoPlay()
    {
        SceneManager.LoadScene("1");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }
}
