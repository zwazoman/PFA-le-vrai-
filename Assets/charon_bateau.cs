using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class charon_bateau : MonoBehaviour
{

    [Header("References")]
    [SerializeField] BezierCurve curve;
    AudioSource _arrivalSource;
    [SerializeField] Animator anim;
    [SerializeField] public Charon charon;

    [Header("Events")]
    [SerializeField] UnityEvent OnArrivee;
    [SerializeField] UnityEvent OnDepart;


    
    [Header("Values")]
    [SerializeField][Range(0, 1)] float TestValue = 1; // cascade : 0  ; quai : 0.329
    [SerializeField] private AnimationCurve _PositionOnCurveOverTime;


    private bool EstDejaParti = false;
    //private bool _tutorial = true;
    private float _timeOffset = 0;

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
        setPositionAlongCurve(TestValue);
    }

#endif

    private void Start()
    {
        if (!introManager.IsActive) { TimeManager.Instance.OnHour += OnHour; }
        TimeManager.Instance.OnTutorialEnd += TutorialEnd;
    }

    public void OnHour()
    {
        if (TimeManager.Instance.Day % 2 == 0) return;

        //StopAllCoroutines();

        //mouvement du bateau
        float actualAlpha = (TimeManager.Instance.Hour + _timeOffset) % 24f ;
        float targetAlpha =  (TimeManager.Instance.Hour + 1 + _timeOffset) % 24f ;
        
        if(TimeManager.Instance.Hour != 23)
        {
            StartCoroutine(Nathan.InterpolateOverTime(actualAlpha, targetAlpha, TimeManager.Instance.IrlHourDuration,(float a)=> { setPositionAlongCurve(_PositionOnCurveOverTime.Evaluate(a)); }, Nathan.Linear, null, true));
        }
        else
        {
            setPositionAlongCurve(0);
        }

        //descente du bateau
        if (TimeManager.Instance.Hour == 7)
        {
            OnArrivee.Invoke();
            DescendreDuBateau();
        }

        //montée sur le bateau + depart
        int hours = Mathf.FloorToInt( (3.1f/(float)TimeManager.Instance.IrlHourDuration)) + 1;//combien d'heures dure son animation pour retourner sur le bateau
        if(TimeManager.Instance.Hour == 11 - hours)
        {
            print("fais dodo charon mon p'tit frère");
            StartCoroutine( Nathan.ExecuteWithDelay(RemonterSurLeBateau, TimeManager.Instance.IrlHourDuration*(hours) - 3.1f,true));
        }


        /*//à 2h il commence son voyage qui dure 5 heures; pour le faire arriver à 7h au port. à 11h il repart ;
        if(TimeManager.Instance.Day % 2  != 1 /*|| _tutorial) // tous les deux jours
        {
            return;
        }
        if (TimeManager.Instance.isSkippingTime /*|| _tutorial) return;


        if (TimeManager.Instance.Hour == 1)
        {  
            StartCoroutine( Nathan.InterpolateOverTime(1, 0.323f, 6 * TimeManager.Instance.IrlHourDuration, setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, Arriver, true));
            OnArrivee.Invoke();
        }
        else if (TimeManager.Instance.Hour == 11)
        {
            Partir();
        }*/
    }

    void DescendreDuBateau()
    {
        _arrivalSource.Play();
        charon.GetComponent<Collider>().enabled = true;
        anim.SetTrigger("arriver");
        EstDejaParti = false;
    }

    public void RemonterSurLeBateau()
    {
        if (EstDejaParti) return;
        OnDepart.Invoke();
        EstDejaParti = true;
        _arrivalSource.Play();
        anim.SetTrigger("partir");
    }

    public void setPositionAlongCurve(float alpha)
    {
        if (curve == null) return;
        transform.position = curve.Sample(alpha);

        Vector3 f = (curve.Sample(1f-alpha) - curve.Sample(1f-(alpha + 1 / 200f))); // la tangente du pauvre
        if (f != Vector3.zero) transform.forward = f;
    }

    void TutorialEnd()
    {
        //_tutorial = false;
    }
}
