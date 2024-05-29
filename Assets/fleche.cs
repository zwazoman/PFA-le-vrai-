using Cinemachine.Utility;
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

    [SerializeField] Sprite CharonSprite;
    [SerializeField] Sprite MoulinSprite;

    public static fleche instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    private void OnDestroy()
    {
        instance = null;
    }


    public void SetUp(Sprite sprite, Transform newTarget)
    {
        image.sprite = sprite;
        target = newTarget;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (target == null) return;
        
        //position
        Vector2 targetPosition = CameraBehaviour.Instance.cam.WorldToScreenPoint(target.position);

        Vector2 endPosition = targetPosition;
        endPosition.x = Mathf.Clamp(endPosition.x, Margin,Screen.width-Margin);
        endPosition.y = Mathf.Clamp(endPosition.y, Margin,Screen.height-Margin);
        GetComponent<RectTransform>().anchoredPosition = endPosition;

        if ((endPosition - new Vector2(Screen.width, Screen.height)).sqrMagnitude < 100 * 100)
        {
            target = null;
            gameObject.SetActive(false);
        }

        //rotation
        Vector2 JENPEUPLU = targetPosition - new Vector2(Screen.width, Screen.height) / 2f;
        LaFleche.rotation = Quaternion.Euler(Vector3.forward * (Mathf.Atan2(JENPEUPLU.y,JENPEUPLU.x)*Mathf.Rad2Deg+90));

        //scale
        transform.localScale = Vector3.one * (1f + Mathf.Sin(Time.time * Frequency) * Amplitude);
        
    }
}
