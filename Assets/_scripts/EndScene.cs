using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScene : MonoBehaviour
{
    [SerializeField] SwitchScene Scene;

    [SerializeField] float duration;
    void Start()
    {
        StartCoroutine(Nathan.InterpolateOverTime(0,100,duration,UpdatePosition,(float v) => { return v; },OnEnd,false));
    }

    void OnEnd()
    {
        Scene.LoadScene("MainMenu");
    }

    private void UpdatePosition(float value)
    {
        transform.position = new Vector3(transform.position.x, value, transform.position.z);
    }
}
