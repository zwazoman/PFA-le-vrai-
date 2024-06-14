using UnityEngine;
public class EndScene : MonoBehaviour
{
    [SerializeField] SwitchScene Scene;

    [SerializeField] float duration;
    void Start()
    {
        StartCoroutine(Nathan.InterpolateOverTime(-48.4f, 100,duration,UpdatePosition,(float v) => { return v; },OnEnd,false));
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
