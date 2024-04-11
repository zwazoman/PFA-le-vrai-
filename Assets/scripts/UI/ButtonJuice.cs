using System.Collections;
using UnityEngine;

public class ButtonJuice : MonoBehaviour
{
    public void ButtonScale()
    {
        StartCoroutine(ScaleModifier());
    }

    IEnumerator ScaleModifier()
    {
        transform.localScale *= 1.3f;
        yield return new WaitForSeconds(0.2f);
        transform.localScale /= 1.3f;
    }
}
