using UnityEngine;

public class FollowsRiver : MonoBehaviour
{
    [SerializeField] BezierCurve _lacurve;
    private void Update()
    {
        transform.position = _lacurve.GetClosestPoint(PlayerMain.Instance.transform.position);
    }
}
