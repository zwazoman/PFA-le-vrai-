using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class xpSource : MonoBehaviour
{
    [SerializeField] VisualEffect prefab;

    List<VisualEffect> fxs = new List<VisualEffect> ();
    public void playFX()
    {
        fxs.Add( Instantiate(prefab, transform.position, Quaternion.identity));
        Destroy(fxs[fxs.Count-1],5);
    }

    private void Update()
    {
        foreach(VisualEffect fx in fxs)
        if(fx!=null) fx.SetVector3("PlayerPosition", PlayerMain.Instance.transform.position); else fxs.Remove(fx);
    }
}
