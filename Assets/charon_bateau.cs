using UnityEngine;

public class charon_bateau : MonoBehaviour
{
    [SerializeField] BezierCurve curve;

    [Range(0,1)]
    public float value = 1; // cascade : 0  ; quai : 0.329

    [SerializeField] GameObject charon;
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
        TimeManager.Instance.OnHour += OnHour;
    }

    void OnHour()
    {

        //à 5h il commence son voyage qui dure deux heures; pour le faire arriver à 7h au port. à11h il repart et traverse la map en 4h;
        if (TimeManager.Instance.Hour == 5)
        {
            print("debout");
            StartCoroutine( Nathan.InterpolateOverTime(0, 0.329f, 2 * TimeManager.Instance.IrlHourDuration, setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); }, activateCharon, true));
        }
        else if (TimeManager.Instance.Hour == 11)
        {
            deActivateCharon();
            StartCoroutine(Nathan.InterpolateOverTime(0.329f, 1, 4 * TimeManager.Instance.IrlHourDuration,  setPositionAlongCurve, (v) => { return Mathf.SmoothStep(0, 1, v); },null,true));
        }

    }

    void setPositionAlongCurve(float alpha)
    {
        if (curve == null) return;
        transform.position = curve.Sample(1 - alpha);

        Vector3 f = curve.Sample(1 - alpha) - curve.Sample(1 - (alpha + 1 / 200f)); // la tangente du pauvre
        if(f!=Vector3.zero) transform.forward = f;
    }

    //temporaire, en attendant d'avoir une animation où il descend du bateau
    void activateCharon() => charon.SetActive(true);
    void deActivateCharon() => charon.SetActive(false);


}
