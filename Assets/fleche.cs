using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fleche : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image image;
    [SerializeField] Transform target;
    [SerializeField] Transform LaFleche;
    bool ShouldFollow;

    [Header("parametres")]
    [SerializeField] float Margin;
    [SerializeField] float Frequency;
    [SerializeField] float Amplitude;
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

        if(ShouldFollow||true)
        {
            //position
            Vector2 targetPosition = CameraBehaviour.Instance.cam.WorldToScreenPoint(target.position);

            Vector2 endPosition = targetPosition;
            endPosition.x = Mathf.Clamp(endPosition.x, Margin,Screen.width-Margin);
            endPosition.y = Mathf.Clamp(endPosition.y, Margin,Screen.height-Margin);
            GetComponent<RectTransform>().anchoredPosition = endPosition;

            //rotation
            Vector2 JENPEUPLU = targetPosition - new Vector2(Screen.width, Screen.height) / 2f;
            LaFleche.rotation = Quaternion.Euler(Vector3.forward * (Mathf.Atan2(JENPEUPLU.y,JENPEUPLU.x)*Mathf.Rad2Deg+90));

            //scale
            transform.localScale = Vector3.one * (1f + Mathf.Sin(Time.time * Frequency) * Amplitude);
        }
    }
}
