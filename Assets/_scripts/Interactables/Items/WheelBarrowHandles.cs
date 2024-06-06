using UnityEngine;

/// <summary>
/// interaction du joueur avec la brouette
/// </summary>
public class WheelBarrowHandles : MonoBehaviour
{
    [SerializeField] float _distanceToLink;
    [SerializeField] float _hightToLink;
    [SerializeField] WheelBarrowStorage _storage;

    [Header("stats mouvements")]
    [SerializeField] float AngularFriction = 9.5f;
    [SerializeField] float vitesse = 8;

    /// <summary>
    /// appel� quand le joueur int�ragit avec la brouette. la snap au joueur recevant sa rotation au passage
    /// </summary>
    public void Equip()
    {
        //stats mouvements
        PlayerMain.Instance.WheelBarrow.Movement._playerMoveSpeed = vitesse;
        PlayerMain.Instance.WheelBarrow.Movement.decelerationY = AngularFriction;


        PlayerMain.Instance.WheelBarrow.Equip();
        _storage.enabled = false;
        UiManager.Instance.Gameplay_Panel.SwitchUI();
        _storage.DisableStorage();
        //visuels

        CameraBehaviour.Instance.target = FindObjectOfType<WheelBarrowMain>().Movement; //t'avais qu'à faire un singleton fdp

        PlayerMain.Instance.WheelBarrow.Movement.enabled = true;

        PlayerMain.Instance.WheelBarrow.WB = this;
        transform.parent = PlayerMain.Instance.WheelBarrowSocket;
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.Euler(PlayerMain.Instance.transform.eulerAngles + Vector3.right * 180 + Vector3.forward * 180);
        //GetComponent<Collider>().enabled = false;
        //changement de collider pour la brouette (gros bordel)
        /*PlayerMain.Instance.PlayerCollider.enabled = false;
        PlayerMain.Instance.WheelBarrowCollider.enabled = true;*/
    }

    public void UnEquip()
    {
        PlayerMain.Instance.WheelBarrow.Movement.enabled = false;
        UiManager.Instance.Gameplay_Panel.SwitchUI();

        transform.parent = null;
        _storage.EnableStorage();

        CameraBehaviour.Instance.target = PlayerMain.Instance.Movement;

        //GetComponent<Collider>().enabled = true;
        /*PlayerMain.Instance.WheelBarrowCollider.enabled = false;
        PlayerMain.Instance.PlayerCollider.enabled = true;*/
    }
}
