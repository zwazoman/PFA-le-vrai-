using System.Collections;
using UnityEngine;

public class charon_bateau : MonoBehaviour
{
    [SerializeField] BezierCurve curve;

    [SerializeField] AudioClip[] _charonArrivalSound;
    [SerializeField] float _CharonArrivalVolume = 1f;

    [Range(0,1)]
    public float value = 1; // cascade : 0  ; quai : 0.329

    [SerializeField] Animator anim;

    [SerializeField] public Charon charon;

    bool EstDejaParti = false;
    private void Update()
    {
        //transform.position = curve.Sample(1-value);
    }

    private void OnValidate()
    {
        setPositionAlongCurve(value);
    }

    private void Start()
    {
        if (!introManager.IsActive) { TimeManager.Instance.OnHour += OnHour; }
    }

    public void OnHour()
    {

        //� 2h il commence son voyage qui dure 5 heures; pour le faire arriver � 7h au port. �11h il repart ;
        if (TimeManager.Instance.Hour == 1)
        {
            StartCoroutine( Nathan.InterpolateOverTime(1, 0.329f, 6 * TimeManager.Instance.IrlHourDuration, setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, Arriver, true));
        }
        else if (TimeManager.Instance.Hour == 11)
        {
            Partir();
        }

    }



    void Arriver()
    {
        anim.SetTrigger("arriver");
        SFXManager.Instance.PlaySFXClip(_charonArrivalSound, transform, _CharonArrivalVolume);
        EstDejaParti = false;
    }

    public void Partir()
    {
        if (EstDejaParti) return;
        EstDejaParti = true;
        anim.SetTrigger("partir");
    }

    public void PartirPourDeVrai()
    {
        StartCoroutine(Nathan.InterpolateOverTime(0.329f, 0 , 3 * TimeManager.Instance.IrlHourDuration, setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, null, true));
    }

    public void setPositionAlongCurve(float alpha)
    {
        if (curve == null) return;
        transform.position = curve.Sample(1 - alpha);

        Vector3 f = (curve.Sample(1 - alpha) - curve.Sample(1 - (alpha + 1 / 200f))); // la tangente du pauvre
        if (f != Vector3.zero) transform.forward = f;
    }




}
