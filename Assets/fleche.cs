using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fleche : MonoBehaviour
{
    [SerializeField] Image image;
    Transform target;
    bool ShouldFollow = false;
    public void setImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetTarget()
    {

    }

    public void Disable()
    {
        
    }

    private void Update()
    {
        if(ShouldFollow)
        {
            //UiManager.
        }
    }
}
