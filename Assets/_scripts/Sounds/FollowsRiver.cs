using UnityEngine;

public class FollowsRiver : MonoBehaviour
{
    [SerializeField] BezierCurve _lacurve;
    Vector3 targetPosition;
    Vector3 vel;
    int frame = 0;
    [SerializeField] float smoothTime = 0.2f;

    private void Update()
    {
        frame = (frame+1)%10;
        if (frame == 5)
        {
            targetPosition = _lacurve.GetClosestPoint(PlayerMain.Instance.transform.position);
        }
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref vel, smoothTime) ;
    }
}
