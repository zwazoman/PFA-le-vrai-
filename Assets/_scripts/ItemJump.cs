using UnityEngine;

/// <summary>
/// gère le saut d'un objet
/// </summary>
public class ItemJump : MonoBehaviour
{
    public Rigidbody RB { get; set; }
    [SerializeField] float _jumpForce = 10;
    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// applique une force a l'objet. Le faisant sauter
    /// </summary>
    public void Jump()
    {
        Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), 0.5f, Random.Range(-0.2f, 0.2f));
        RB.AddForce(direction * _jumpForce, ForceMode.Impulse); // fait sauter l'objet lorsqu'il est instancié
    }
}
