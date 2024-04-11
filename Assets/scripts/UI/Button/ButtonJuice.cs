using System.Collections;
using UnityEngine;

public class ButtonJuice : MonoBehaviour
{

    public void ButtonScale()
    {
        StartCoroutine(UpdateScale());
    }

    IEnumerator UpdateScale()
    {
        transform.localScale *= 1.3f;
        yield return new WaitForSeconds(0.08f);
        transform.localScale /= 1.3f;
    }
}
