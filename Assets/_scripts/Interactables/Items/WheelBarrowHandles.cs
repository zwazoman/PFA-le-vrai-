using UnityEngine;

/// <summary>
/// interaction du joueur avec la brouette
/// </summary>
public class WheelBarrowHandles : Interactable
{
    [SerializeField] float _distanceToLink;
    [SerializeField] float _hightToLink;
    [SerializeField] WheelBarrowStorage _storage;

    /// <summary>
    /// appel� quand le joueur int�ragit avec la brouette. la snap au joueur recevant sa rotation au passage
    /// </summary>
    protected override void Interaction()
    {
        PlayerMain.Instance.WheelBarrow.Equip();
        _storage.enabled = false;
        //visuels

        CameraBehaviour.Instance.target = FindObjectOfType<WheelBarrowMain>().Movement; //t'avais qu'à faire un singleton fdp

        PlayerMain.Instance.WheelBarrow.WB = this;
        transform.parent = PlayerMain.Instance.transform;
        transform.position = PlayerMain.Instance.transform.position + PlayerMain.Instance.transform.forward * _distanceToLink + Vector3.up * _hightToLink;
        transform.rotation = Quaternion.Euler(PlayerMain.Instance.transform.eulerAngles + Vector3.right * 180 + Vector3.forward * 180);
        GetComponent<Collider>().enabled = false;
        //changement de collider pour la brouette (gros bordel)
        /*PlayerMain.Instance.PlayerCollider.enabled = false;
        PlayerMain.Instance.WheelBarrowCollider.enabled = true;*/
    }

    public void UnEquip()
    {
        transform.parent = null;
        _storage.enabled = true;

        CameraBehaviour.Instance.target = PlayerMain.Instance.Movement;

        GetComponent<Collider>().enabled = true;
        /*PlayerMain.Instance.WheelBarrowCollider.enabled = false;
        PlayerMain.Instance.PlayerCollider.enabled = true;*/
    }
}
