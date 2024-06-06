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

    Image[] imageList;

    private void Awake()
    {
        imageList = GetComponentsInChildren<Image>();
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

    private void UpdateOpacity(float a)
    {
        foreach(Image image in imageList)
        {
            Color color = image.color;
            color.a = Mathf.Lerp(0, 1, a);
            image.color = color;
        }
    }

    public void SetUp(flecheTriggerDeCon f)
    {

        print("b");

        if (currentTarget == null )
        {
            print("c1");

            currentTarget = f;
            image.sprite = f.sprite;
            target = f.target;
            gameObject.SetActive(true);
        }
        else if(currentTarget.Priority < f.Priority)
        {
            print("c2");

            currentTarget = f;
            image.sprite = f.sprite;
            target = f.target;
            gameObject.SetActive(true);
        }
        else
        {
            print("c3 pute");

        }

    }

    private void Update()
    {
        if (currentTarget == null) return;
        
        //position
        Vector3 targetPosition = CameraBehaviour.Instance.cam.WorldToScreenPoint(target.position);
         
        Vector2 endPosition = (Vector2)targetPosition;

        endPosition.x = Mathf.Clamp(targetPosition.x, Margin ,Screen.width - Margin);
        endPosition.y = Mathf.Clamp(targetPosition.y, Margin, Screen.height - Margin);


        UpdateOpacity(Vector2.Distance(endPosition, targetPosition)/900);
        if (targetPosition.z < 0) { UpdateOpacity(0); }

        //Vector2 offset = targetPosition - endPosition;
        GetComponent<RectTransform>().anchoredPosition = endPosition;

        /*if ((endPosition - new Vector2(Screen.width/2f, Screen.height/2f)).sqrMagnitude < 500 * 500)
        {
            Cancel();
        }*/

        //rotation
        Vector2 JENPEUPLU = (Vector2)targetPosition - new Vector2(Screen.width, Screen.height) / 2f;
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
