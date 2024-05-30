using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Permet de gerer les scenes
/// </summary>

public class SwitchScene : MonoBehaviour
{
    [SerializeField] GameObject _loadingScreen;

    private void Awake()
    {
        _loadingScreen.SetActive(false); 
    }

    public void LoadScene(string scene)
    {
        _loadingScreen.SetActive(true);

        List<AsyncOperation> ops = new List<AsyncOperation>();
        ops.Add(SceneManager.LoadSceneAsync(scene));

        StartCoroutine(Loading(ops));
    }   

    private IEnumerator Loading(List<AsyncOperation> ops)
    {
        for (int i = 0; i < ops.Count; i++)
        {
            while (!ops[i].isDone)
            {
                yield return null;
            }
        }
        //_loadingScreen.enabled = false;
    }
    
    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }
}
