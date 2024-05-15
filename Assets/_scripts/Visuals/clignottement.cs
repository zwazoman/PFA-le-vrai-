using UnityEngine;
using UnityEngine.UI;

public class clignottement : MonoBehaviour
{
    [SerializeField] Image image;
    float frequence = 0.4f;
    private void OnEnable()
    {
        image.enabled = true;
        InvokeRepeating("toggle", frequence, frequence);        
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void toggle()
    {
        image.enabled = !image.enabled;
    }

}
