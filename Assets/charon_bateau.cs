using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class charon_bateau : MonoBehaviour
{
    [SerializeField] BezierCurve curve;

    AudioSource _arrivalSource;

    [Range(0,1)]
    public float value = 1; // cascade : 0  ; quai : 0.329

    [SerializeField] Animator anim;

    [SerializeField] public Charon charon;

    bool EstDejaParti = false;
    bool _tutorial = true;

    [SerializeField] UnityEvent OnArrivee;
    [SerializeField] UnityEvent OnDepart;

    private void Awake()
    {
        _arrivalSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //transform.position = curve.Sample(1-value);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        setPositionAlongCurve(value);
    }

#endif

    private void Start()
    {
        if (!introManager.IsActive) { TimeManager.Instance.OnHour += OnHour; }
        TimeManager.Instance.OnTutorialEnd += TutorialEnd;
    }

    public void OnHour()
    {

        //à 2h il commence son voyage qui dure 5 heures; pour le faire arriver à 7h au port. à 11h il repart ;
        if(TimeManager.Instance.Day % 2  != 1 /*|| _tutorial*/) // tous les deux jours
        {
            return;
        }
        if (TimeManager.Instance.isSkippingTime /*|| _tutorial*/) return;


        if (TimeManager.Instance.Hour == 1)
        {
            StartCoroutine( Nathan.InterpolateOverTime(1, 0.323f, 6 * TimeManager.Instance.IrlHourDuration, setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, Arriver, true));
            OnArrivee.Invoke();

        }
        else if (TimeManager.Instance.Hour == 11)
        {
            Partir();
        }
    }

    void Arriver()
    {
        _arrivalSource.Play();
        print("arriver là");
        charon.GetComponent<Collider>().enabled = true;

        anim.SetTrigger("arriver");
        EstDejaParti = false;
    }

    public void Partir()
    {
        if (EstDejaParti) return;
        OnDepart.Invoke();

        EstDejaParti = true;
        _arrivalSource.Play();
        anim.SetTrigger("partir");
    }

    public void PartirPourDeVrai()
    {
        StartCoroutine(Nathan.InterpolateOverTime(0.323f, 0 , 3 * TimeManager.Instance.IrlHourDuration, setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, null, true));
    }

    public void setPositionAlongCurve(float alpha)
    {
        if (curve == null) return;
        transform.position = curve.Sample(1 - alpha);

        Vector3 f = (curve.Sample(1 - alpha) - curve.Sample(1 - (alpha + 1 / 200f))); // la tangente du pauvre
        if (f != Vector3.zero) transform.forward = f;
    }

    void TutorialEnd()
    {
        _tutorial = false;
    }
}
