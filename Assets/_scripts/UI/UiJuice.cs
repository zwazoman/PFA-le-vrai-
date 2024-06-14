using UnityEngine;


public class UiJuice : MonoBehaviour
{

    Vector3 BaseScale;
    private void Awake()
    {
        BaseScale = transform.localScale;
    }
    public void ScaleUp()
    {
        //EventTriggerType.PointerEnter.
        gameObject.transform.localScale = BaseScale * 1.2f;
       
    }
    public void ScaleDown() 
    {
        gameObject.transform.localScale = BaseScale / 1.2f;
    }

    /*public void ChangeScale() => StartCoroutine(_ChangeScale());
    private IEnumerator _ChangeScale()
    {
        gameObject.transform.localScale *= 1.3f;
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.localScale /= 1.3f;
    }*/
}
