using UnityEngine;
using UnityEngine.UIElements;

public class Eve : Interactable
{
    [SerializeField] private string DialogueScript;
    [SerializeField] private Animator _animator;
    [SerializeField] door porte;
    public int price = 500;

    public Transform eve;
    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }

    public void ManageQuests()
    {
        QuestManager.Instance.TryProgressQuest("FindSoul", 1);
        QuestManager.Instance.TryProgressQuest("BuySoul", PlayerMain.Instance.Stats.Money);
    }

    public void OuvrirPorte()
    {

        //_animator.SetLayerWeight(1, 0);
        
        porte.Open();
    }

    /*private void Update()
    {
        Vector3 pose = new Vector3(0.0818037838f, 0.0158190597f, 0.0152999731f);
        Quaternion angle = new Quaternion(0.512313664f, 0.487375349f, 0.487375349f, 0.512313664f);
        eve.localPosition = pose;
        eve.localRotation = angle;
    }*/

    public void CommencerAnimation()
    {
        //_animator.SetLayerWeight(1, 1);
        //_animator.SetTrigger("bougeSaMere");
        Vector3 basePose = eve.transform.localPosition;
        Quaternion baseRot = eve.transform.localRotation;
        Vector3 pose = new Vector3(0.0818037838f, 0.0158190597f, 0.0152999731f);
        Quaternion angle = new Quaternion(0.512313664f, 0.487375349f, 0.487375349f, 0.512313664f);
        foreach(Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 1f, (float a) =>
        {
            eve.localPosition = Vector3.Lerp(basePose,pose,a);
            eve.localRotation = Quaternion.Lerp(baseRot, angle,a) ;
        },Nathan.SmoothStep01,OuvrirPorte));
    }
}
