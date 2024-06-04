using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VelocityTrigger : MonoBehaviour
{
    [SerializeField] float treshold = 0.2f;
    public bool isMoving = false;

    Vector3 OldPosition ;

    public UnityEvent OnMove;
    public UnityEvent OnStopMoving;

    private void Start()
    {
        OnStopMoving.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        float sqrMagnitude = (transform.position - OldPosition).sqrMagnitude;
        bool m = (sqrMagnitude * sqrMagnitude)/Time.deltaTime > treshold * treshold;

        if(m!=isMoving)
        {
            if (m)
            {
                OnMove?.Invoke();
            }
            else if (!m)
            {
                OnStopMoving?.Invoke();
            }

            isMoving = m;
        }
        
    }

    private void LateUpdate()
    {
        OldPosition = transform.position;
    }
}
