using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    GameObject _optionPanel;


    public void GoPlay()
    {
        SceneManager.LoadScene("1");
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }

    public void GoOptions()
    {
        _optionPanel.SetActive(!true);
    }
}
