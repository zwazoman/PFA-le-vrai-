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

    public flecheTriggerDeCon currentTarget;

    public static fleche instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Cancel();
    }

    private void OnDestroy()
    {
        instance = null;   
    }

    public void SetUp(flecheTriggerDeCon f)
    {
        if (currentTarget == null) return;
        if (currentTarget.Priority < f.Priority)
        {
            currentTarget = f;
            image.sprite = f.sprite;
            target = f.target;
            gameObject.SetActive(true);
        }
        
    }

    private void Update()
    {
        if (currentTarget == null) return;
        
        //position
        Vector2 targetPosition = CameraBehaviour.Instance.cam.WorldToScreenPoint(target.position);
         
        Vector2 endPosition = targetPosition;
        endPosition.x = Mathf.Clamp(endPosition.x, Margin * Screen.width, (Screen.width - Margin)*Screen.width);
        endPosition.y = Mathf.Clamp(endPosition.y, Margin * Screen.height, (Screen.height - Margin)*Screen.height);
        
        Vector2 offset = targetPosition - endPosition;
        GetComponent<RectTransform>().anchoredPosition = endPosition;

        /*if ((endPosition - new Vector2(Screen.width/2f, Screen.height/2f)).sqrMagnitude < 500 * 500)
        {
            Cancel();
        }*/

        //rotation
        Vector2 JENPEUPLU = targetPosition - new Vector2(Screen.width, Screen.height) / 2f;
        LaFleche.rotation = Quaternion.Euler(Vector3.forward * (Mathf.Atan2(JENPEUPLU.y,JENPEUPLU.x)*Mathf.Rad2Deg+90));

        //scale
        transform.localScale = Vector3.one * (1f + Mathf.Sin(Time.time * Frequency) * Amplitude);
        
    }

    public void Cancel()
    {
        currentTarget = null;
        gameObject.SetActive(false);
    }
}
