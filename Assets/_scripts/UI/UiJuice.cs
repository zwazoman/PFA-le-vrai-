using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UiJuice : MonoBehaviour
{
    public void ScaleUp()
    {
        //EventTriggerType.PointerEnter.
        gameObject.transform.localScale *= 1.2f;
       
    }
    public void ScaleDown() 
    {
        gameObject.transform.localScale /= 1.2f;
    }

    /*public void ChangeScale() => StartCoroutine(_ChangeScale());
    private IEnumerator _ChangeScale()
    {
        gameObject.transform.localScale *= 1.3f;
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.localScale /= 1.3f;
    }*/
}
